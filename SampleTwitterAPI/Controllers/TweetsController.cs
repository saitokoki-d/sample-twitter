using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleTwitterAPI.Models;

namespace SampleTwitterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly SampleTwitterContext _context;

        public TweetsController(SampleTwitterContext context)
        {
            _context = context;
        }

        // GET: api/Tweets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tweet>>> GetTweet()
        {
          if (_context.Tweet == null)
          {
              return NotFound();
          }
            // 作成日時降順
            return await _context.Tweet.OrderByDescending(t => t.CreatedAt).ToListAsync();
        }

        // GET: api/Tweets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Tweet>>> GetTweet(int id)
        {
          if (_context.Tweet == null)
          {
              return NotFound();
          }
            var tweet = await _context.Tweet.Where(b => b.ProfileId == id).ToListAsync();

            if (tweet == null)
            {
                return NotFound();
            }

            return tweet;
        }

        // PUT: api/Tweets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTweet(int id, Tweet tweet)
        {
            if (id != tweet.Id)
            {
                return BadRequest();
            }

            _context.Entry(tweet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TweetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tweets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tweet>> PostTweet(Tweet tweet)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine(tweet);

            if (_context.Tweet == null)
            {
                return Problem("Entity set 'SampleTwitterContext.Tweet'  is null.");
            }
            _context.Tweet.Add(tweet);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTweet), new { id = tweet.Id }, tweet);
        }

        // DELETE: api/Tweets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTweet(int id)
        {
            if (_context.Tweet == null)
            {
                return NotFound();
            }
            var tweet = await _context.Tweet.FindAsync(id);
            if (tweet == null)
            {
                return NotFound();
            }

            _context.Tweet.Remove(tweet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TweetExists(int id)
        {
            return (_context.Tweet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
