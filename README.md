# CrossPoster

X(Twitter), Bluesky, Misskeyにテキストと画像を同時投稿できるWindowsデスクトップアプリケーションです。

## 主な機能

-   複数のSNSアカウントへの一括投稿
-   画像メディアの添付（1ファイル）
-   メディアのファイルサイズ事前チェック機能
-   各SNSの文字数制限カウンター
-   APIキーなどを設定ファイルで管理
-   前回使用したSNSの選択状態を記憶

## 使い方

1.  アプリケーションを起動します。**新しいバージョンがリリースされている場合、ダイアログでお知らせします。**
2.  メニューの「オプション」→「設定」から、各SNSのAPIキーやアカウント情報を入力して保存します。
3.  テキストボックスに投稿したい内容を入力します。
4.  （任意）「メディア選択」ボタンから、投稿に添付したい画像ファイルを1つ選択します。
    -   **各SNSのファイルサイズ上限を超えている場合、投稿ボタンを押す前にUI上で通知されます。**
5.  投稿したいSNSのチェックボックスをONにします。（前回投稿したSNSは自動でONになります）
6.  「送信」ボタンをクリックします。

## 注意事項

-   このアプリケーションを利用するには、各SNSのAPIキーなどが必要です。設定画面から正しく入力してください。
-   添付できるメディアは1つの投稿につき1ファイルのみです。

## 開発環境
-   .NET 8.0
-   C# 12.0
-   Visual Studio 2022
-   Windows 10以降
-   NuGetパッケージ:
    -   TweetinviAPI
    -   X.Bluesky
    -   Newtonsoft.Json
    -   ini-parser-netstandard
    -   System.Drawing.Common

## インストール方法
リリースページから最新のバージョンをダウンロードし、実行してください。


## 更新履歴
-   **v1.2.2** (2025-08-24)
    -   更新確認機能の処理変更
-   **v1.2.1** (2025-08-24)
    -   Misskeyへの投稿時に改行が正しく反映されない不具合を修正
-   **v1.2.0** (2025-08-20)
    -   起動時に新しいバージョンがリリースされていないか確認する機能を追加
    -   メディアのファイルサイズが各SNSの上限を超えていないか事前にチェックする機能を追加
-   **v1.1.0** (2025-08-20)
    -   メディア添付機能を追加
    -   前回使用したSNSの選択状態を記憶する機能を追加
-   **v1.0.1** (2025-07-13)
    -   文字数制限カウンターの表示方法修正
-   **v1.0.0** (2025-07-06)
    -   初版リリース

## 📄 ライセンス (License)

このプロジェクトは **MIT ライセンス** の下で公開されています。
これは、ソフトウェアで最も広く使われている、非常に寛容な（ゆるい）ライセンスです。

### ひと目でわかるライセンス要約

#### ✅ 可能なこと (ほぼ何でもできます)

* **商用利用**: このアプリ（またはコード）を使って利益を上げても構いません。
* **改変**: 自由にコードを改造できます。
* **再配布**: 改造したかどうかにかかわらず、コピーを他の人に配っても構いません。
* **プライベート利用**: このコードを公開せずに、個人的な目的や社内のみで利用しても構いません。

#### ⚠️ 守っていただきたい義務 (たった1つだけです)

* **著作権表示の保持**:
    このソフトウェア（のコードや実行ファイル）を再配布する場合、必ず以下の**ライセンス条文（全文）**と**著作権表示（Copyright行）**を、ソフトウェアのコピーまたは重要な部分（例: Readmeやライセンスファイル）に**そのまま含めてください**。

#### 🚫 免責事項 (重要な注意点)

* このソフトウェアは「現状のまま（AS IS）」提供されます。
* このソフトウェアを使用したことによって生じたいかなる損害（PCが壊れた、データが消えた等）についても、**作者（マッシャー (Masher)）は一切の責任を負いません**。ご利用は自己責任でお願いいたします。

---

### MIT ライセンス条文 (全文)

Copyright (c) 2025 マッシャー (Masher)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

---

### 📦 依存ライブラリのライセンス (Third-Party Licenses)

本ソフトウェアは、以下のサードパーティ製ライブラリを利用しており、これらのライブラリも（本プロジェクトと互換性のある）MITライセンスの下で提供されています。

* **TweetinviAPI** (MIT License)
* **X.Bluesky** (MIT License)
* **Newtonsoft.Json** (MIT License)
* **ini-parser-netstandard** (MIT License)
* **System.Drawing.Common** (MIT License)
