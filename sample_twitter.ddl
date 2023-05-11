CREATE DATABASE IF NOT EXIST sample_twitter;

use sample_twitter;

CREATE TABLE profile (
    id INT AUTO_INCREMENT NOT NULL PRIMARY KEY COMMENT 'ID',
    twitter_id VARCHAR(50) COMMENT 'ツイッターID',
    name VARCHAR(255) COMMENT '名前',
    profile_img VARCHAR(255) COMMENT 'プロフィール画像',
    profile_bg_img VARCHAR(255) COMMENT 'プロフィール背景画像',
    follow_count INT(11) COMMENT 'フォロー数',
    follower_count INT(11) COMMENT 'フォロワー数',
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '作成日時'
);

CREATE TABLE tweet (
    id INT AUTO_INCREMENT NOT NULL PRIMARY KEY COMMENT 'ID',
    profile_id INT COMMENT 'プロフィールID',
    text VARCHAR(255) COMMENT 'ツイート内容',
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '作成日時',
    FOREIGN KEY (profile_id) REFERENCES profile (id)
);

INSERT INTO sample_twitter.profile VALUES
(
  null,
  '@miwamiwa-yoitomake',
  '美輪明宏',
  '/img/miwa-icon.png',
  '/img/miwa-bg.jpg',
  '父ちゃんのためなら　エンヤコラ<br />母ちゃんのためなら　エンヤコラ',
  205000,
  2,
  null
);

commit;
