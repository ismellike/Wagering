<template>
  <span>
    <div class="hero-body is-block">
      <div class="container">
        <h1 class="title has-text-centered">Wagering.gg FAQ</h1>
        <section class="section">
          <div class="container">
            <h2 class="title">
              <span class="has-text-primary">#</span>Cryptocurrency
            </h2>
            <QuestionAnswer
              question="What is cryptocurrency?"
              answer="Cryptocurrency is a digital currency - protected by cryptography - operating independently from a central system like a bank, government, or business."
            />
            <QuestionAnswer
              question="Why is cryptocurrency necessary?"
              answer="With cryptocurrency, users can seamlessly send eachother currency without the need for a middleman taking a portion or controlling their funds."
            />
            <QuestionAnswer
              question="Where is cryptocurrency stored?"
              answer="Just like traditional currency, cryptocurrency is also stored in your wallet. Many types of cryptocurrency wallets exist: hardware wallets, desktop wallets, mobile wallets, and web wallets."
            />
            <QuestionAnswer
              question="How do wallets work?"
              answer="Each user's wallet will have a public and private key. Public keys are used for receiving money. Private keys are used for authorizing transactions."
            />
            <QuestionAnswer
              question="Where can I get cryptocurrency?"
              answer="Cryptocurrency can either be bought from exchanges or earned from trading, browsing, mining, staking, wagering, bounties, etc."
            />
          </div>
        </section>
      </div>
    </div>
    <section class="hero is-small is-light is-bold">
      <div class="hero-body">
        <div class="container">
          <div class="columns">
            <div class="column is-half is-offset-one-quarter">
              <figure class="image">
                <img src="@/assets/stellar.png" />
              </figure>
            </div>
          </div>
        </div>
      </div>
    </section>
    <div class="hero-body is-block">
      <div class="container">
        <section class="section">
          <div class="container">
            <h2 class="title">
              <span class="has-text-primary">#</span>Stellar
            </h2>
            <QuestionAnswer
              question="What is Stellar Lumens?"
              answer="Stellar is our preferred cryptocurrency network system. Lumens (XLM) is the network's native currency."
            />
            <QuestionAnswer
              question="Why is Stellar Lumens our preferred cryptocurrency?"
              answer="Stellar is lead by an experienced nonprofit organization offering extremely low transaction fees while offering quick transfers of money (~5 seconds). Stellar also provides smart contract capabilities for handling complex payment scenarios."
            />
            <QuestionAnswer
              question="What transaction fees does Stellar have?"
              answer="The minimum transaction fee is a flat fee of .00001 lumen per operation, and that's only to deter spam behavior on the network. Compare this with traditional methods charging a standard fee of 2.9%+.30 per transaction - or even more depending on where you send it and how much is sent: Stellar Lumens easily comes out on top."
            />
          </div>
        </section>
      </div>
    </div>
    <section class="hero is-primary is-bold">
      <div class="hero-body">
        <section class="section"></section>
      </div>
    </section>
    <div class="hero-body is-block">
      <div class="container">
        <section class="section">
          <div class="container">
            <h2 class="title">
              <span class="has-text-primary">#</span>Wagering.gg
            </h2>
            <QuestionAnswer
              question="Why should I use Wagering.gg?"
              answer="Wagering.gg offers a modern platform for finding, accepting, and handling wagers. Unlike other platforms, our service allows users to keep control of their funds entirely."
            />
            <QuestionAnswer
              question="How does Wagering.gg work?"
              answer="Utilizing smart contracts on the Stellar network, Wagering.gg can award funds directly between accounts and can create complex payment scenarios. Imagine a scenario where 100 people enter a tournament with money, and the top 10 earn a portion of the pool. With smart contracts, this is possible."
            />
            <QuestionAnswer
              question="How much are service fees?"
              answer="Our service fee is 10% - or 5% for verified users - of the loser's wager amount. A standard percentage rate keeps the process simple and allows for low-value wagers to be feasible."
            />
          </div>
        </section>
        <section class="section">
          <div class="container">
            <h2 class="title">
              <span class="has-text-primary">#</span>Resources
            </h2>
            <h3 class="subtitle">
              <span class="has-text-primary">##</span>Exchanges
            </h3>
            <div class="buttons">
              <a
                class="button is-primary is-outlined"
                target="_blank"
                href="https://www.stellarx.com/"
              >StellarX</a>
              <a
                class="button is-primary is-outlined"
                target="_blank"
                href="https://www.coinbase.com/join/lopez_rdfi"
              >Coinbase</a>
              <a
                class="button is-primary is-outlined"
                target="_blank"
                href="https://pro.coinbase.com/"
              >Coinbase Pro</a>
              <a
                class="button is-primary is-outlined"
                target="_blank"
                href="https://shapeshift.io/"
              >Shapeshift</a>
            </div>
            <h3 class="subtitle">
              <span class="has-text-primary">##</span>Earning
            </h3>
            <a
              class="button is-primary is-outlined"
              target="_blank"
              href="https://brave.com/?ref=ism355"
            >Brave</a>
            <a
              class="button is-primary is-outlined"
              target="_blank"
              href="https://bounty0x.io/"
            >Bounty0x</a>
          </div>
        </section>
      </div>
    </div>
  </span>
</template>
<script>
import QuestionAnswer from "../components/QuestionAnswer";
export default {
  components: {
    QuestionAnswer
  }
};
</script>