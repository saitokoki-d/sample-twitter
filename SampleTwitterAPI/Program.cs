using Microsoft.EntityFrameworkCore;
using SampleTwitterAPI.Models;

// ========== WebApplication�r���_�[���� ==========
var builder = WebApplication.CreateBuilder(args);

// �R���g���[���[�ǉ�
builder.Services.AddControllers();

// DB��Model���Ȃ���
// appsettings.json�̕�����i�ڑ����j�����������Ă��ēn���Ă�
ConfigurationManager configuration = builder.Configuration;
string? mysqlConnecrionStr = configuration.GetConnectionString("SampleTwitterDb");
builder.Services.AddDbContext<SampleTwitterContext>(options =>
    options.UseMySql(mysqlConnecrionStr, ServerVersion.AutoDetect(mysqlConnecrionStr)));

// API�@�\���� �R���g���[���[�Ƀp�X�����蓖�Ă���
builder.Services.AddEndpointsApiExplorer();

var AllowAllOriginsPolicy = "AllowAllOriginsPolicy";

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowAllOriginsPolicy, // ���O�͉��ł��ǂ�
      policy =>
      {
          // 9000�Ԃ�Quasar�J����
          policy.WithOrigins("http://localhost:9000", "https://localhost:9000").AllowAnyHeader();
      });
});

// Swagger(OpenAPI��֗��Ɏg�p����c�[��)�𗘗p����
//builder.Services.AddSwaggerGen();

// ========== WebApplication�C���X�^���X���� ==========
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // �J�����̏ꍇSwaggerUI�y�[�W��\��
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

// ���_�C���N�g�~�h���E�F�A�ǉ�
app.UseHttpsRedirection();

// �f�t�H���g�t�@�C���g�p�iindex.html�Ƃ��j
app.UseDefaultFiles();

// wwwroot�f�B���N�g���g�p
app.UseStaticFiles();


// �F�؋@�\�ǉ�
//app.UseAuthorization();

// �R���g���[���[�̑������[�e�B���O���}�b�v
app.MapControllers();

// SPA�Ȃ̂�html�t�@�C��1�̒��iindex.html�̒��j��js���y�[�W���o�������Ă���B
// �˂�������SPA��index.html�ɓ��B���Ȃ��A�N�Z�X("/"�ȊO)�̏ꍇ�ASPA�͓����Ȃ��B
// �˂��̃v���W�F�N�g�֑��݂��Ȃ�URL�ւ̃A�N�Z�X("/"��"/api"�ȊO)�̏ꍇ��index.html�ɔ�΂��āA
// �@SPA���Ń��[�e�B���O���ăy�[�W��\������B
app.MapFallbackToFile("/index.html");

// CORS�̃|���V�[��K�p
app.UseCors(AllowAllOriginsPolicy);

// ����I�A�v���P�[�V�����I
app.Run();
