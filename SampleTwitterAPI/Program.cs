using Microsoft.EntityFrameworkCore;
using SampleTwitterAPI.Models;

// ========== WebApplicationビルダー生成 ==========
var builder = WebApplication.CreateBuilder(args);

// コントローラー追加
builder.Services.AddControllers();

// DBとModelをつなげる
// appsettings.jsonの文字列（接続情報）を引っ張ってきて渡してる
ConfigurationManager configuration = builder.Configuration;
string? mysqlConnecrionStr = configuration.GetConnectionString("SampleTwitterDb");
builder.Services.AddDbContext<SampleTwitterContext>(options =>
    options.UseMySql(mysqlConnecrionStr, ServerVersion.AutoDetect(mysqlConnecrionStr)));

// API機能実装 コントローラーにパスが割り当てられる
builder.Services.AddEndpointsApiExplorer();

var AllowAllOriginsPolicy = "AllowAllOriginsPolicy";

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowAllOriginsPolicy, // 名前は何でも良い
      policy =>
      {
          // 9000番はQuasar開発環境
          policy.WithOrigins("http://localhost:9000", "https://localhost:9000").AllowAnyHeader();
      });
});

// Swagger(OpenAPIを便利に使用するツール)を利用する
//builder.Services.AddSwaggerGen();

// ========== WebApplicationインスタンス生成 ==========
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // 開発環境の場合SwaggerUIページを表示
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

// リダイレクトミドルウェア追加
app.UseHttpsRedirection();

// デフォルトファイル使用（index.htmlとか）
app.UseDefaultFiles();

// wwwrootディレクトリ使用
app.UseStaticFiles();


// 認証機能追加
//app.UseAuthorization();

// コントローラーの属性ルーティングをマップ
app.MapControllers();

// SPAなのでhtmlファイル1つの中（index.htmlの中）でjsがページを出し分けている。
// ⇒そもそもSPAのindex.htmlに到達しないアクセス("/"以外)の場合、SPAは動かない。
// ⇒このプロジェクトへ存在しないURLへのアクセス("/"と"/api"以外)の場合はindex.htmlに飛ばして、
// 　SPA内でルーティングしてページを表示する。
app.MapFallbackToFile("/index.html");

// CORSのポリシーを適用
app.UseCors(AllowAllOriginsPolicy);

// 走れ！アプリケーション！
app.Run();
