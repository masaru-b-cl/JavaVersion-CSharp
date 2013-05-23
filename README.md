JavaVersion-CSharp
==================

TDDBC 長岡 1.0の演習をC#で解いてみました。

[TDD Boot Camp(TDDBC) - TDDBC長岡1.0/演習](http://devtesting.jp/tddbc/?TDDBC%E9%95%B7%E5%B2%A11.0%2F%E6%BC%94%E7%BF%92)

# ポイント
- テスティングフレームワークは[MSTest](http://codezine.jp/article/detail/6382)
- サポートライブラリに[Chaining Assertion](http://chainingassertion.codeplex.com/)
- テストケースにはカテゴリーを付け、partialクラスを用いて複数ファイルに分割
- Versionという名前はSystem.Versionクラスで予約済みなので、JdkVersionに変更
- JdkVersionはイミュータブルなValueObjectとして、structとして定義
