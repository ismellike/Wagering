<template>
    <!--Decided to use USDC stablecoin with Nethereum and circle api-->
    <v-container>
        <v-container>
            <h1 class="display-2">
                <v-icon large color="accent">mdi-pound</v-icon>
                Cryptocurrency
            </h1>
        </v-container>
        <v-container>
            <v-expansion-panels inset hover>
                <v-expansion-panel>
                    <v-expansion-panel-header class="headline">What is cryptocurrency?</v-expansion-panel-header>
                    <v-expansion-panel-content class="body-1">
                        Cryptocurrency is a digital currency - protected by cryptography -
                        operating independently from a central system like a bank, government,
                        or business.
                    </v-expansion-panel-content>
                </v-expansion-panel>
                <v-expansion-panel>
                    <v-expansion-panel-header class="headline">Why is cryptocurrency necessary?</v-expansion-panel-header>
                    <v-expansion-panel-content class="body-1">
                        Cryptocurrencies have many benefits for Wagering.gg: transfers are
                        near-instantaneous and cheap, money is securely stored in the user's
                        own wallet, and some cryptocurrencies can be programmatically
                        transferred.
                    </v-expansion-panel-content>
                </v-expansion-panel>
                <v-expansion-panel>
                    <v-expansion-panel-header class="headline">How do wallets work?</v-expansion-panel-header>
                    <v-expansion-panel-content class="body-1">
                        Each user's wallet will have a public and private key. Public keys are
                        used for receiving money. Private keys are used for authorizing
                        transactions. A private key should never be shared with another user.
                    </v-expansion-panel-content>
                </v-expansion-panel>
                <v-expansion-panel>
                    <v-expansion-panel-header class="headline">Where can I get cryptocurrency?</v-expansion-panel-header>
                    <v-expansion-panel-content class="body-1">
                        Cryptocurrency can either be bought from exchanges or earned from
                        trading, browsing, mining, staking, wagering, bounties, etc.
                    </v-expansion-panel-content>
                </v-expansion-panel>
            </v-expansion-panels>
        </v-container>
        <v-container>
            <h1 class="display-2">
                <v-icon large color="accent">mdi-pound</v-icon>
                Stellar
            </h1>
        </v-container>
        <v-container>
            <v-expansion-panels inset hover>
                <v-expansion-panel>
                    <v-expansion-panel-header class="headline">What is Stellar Lumens?</v-expansion-panel-header>
                    <v-expansion-panel-content class="body-1">
                        Stellar is our preferred cryptocurrency network system. Lumens (XLM)
                        is the network's native currency.
                    </v-expansion-panel-content>
                </v-expansion-panel>
                <v-expansion-panel>
                    <v-expansion-panel-header class="headline">
                        Why is Stellar Lumens our preferred
                        cryptocurrency?
                    </v-expansion-panel-header>
                    <v-expansion-panel-content class="body-1">
                        Stellar is lead by an experienced nonprofit organization offering
                        extremely low transaction fees while offering quick transfers of money
                        (~5 seconds). Stellar also provides smart contract capabilities for
                        handling complex payment scenarios.
                    </v-expansion-panel-content>
                </v-expansion-panel>
                <v-expansion-panel>
                    <v-expansion-panel-header class="headline">What transaction fees does Stellar have?</v-expansion-panel-header>
                    <v-expansion-panel-content class="body-1">
                        The minimum transaction fee is a flat fee of .00001 lumen per
                        operation, and that's only to deter spam behavior on the network.
                        Compare this with traditional methods charging a standard fee of
                        2.9%+.30 per transaction - or even more depending on where you send it
                        and how much is sent: Stellar Lumens easily comes out on top.
                    </v-expansion-panel-content>
                </v-expansion-panel>
            </v-expansion-panels>
        </v-container>
        <v-container>
            <h1 class="display-2">
                <v-icon large color="accent">mdi-pound</v-icon>
                Wagering.gg
            </h1>
        </v-container>
        <v-container>
            <v-expansion-panels inset hover>
                <v-expansion-panel>
                    <v-expansion-panel-header class="headline">Why should I use Wagering.gg?</v-expansion-panel-header>
                    <v-expansion-panel-content class="body-1">
                        Wagering.gg offers a modern platform for finding, accepting, and
                        handling wagers. Unlike other platforms, our service allows users to
                        keep control of their funds entirely.
                    </v-expansion-panel-content>
                </v-expansion-panel>
                <v-expansion-panel>
                    <v-expansion-panel-header class="headline">How does Wagering.gg work?</v-expansion-panel-header>
                    <v-expansion-panel-content class="body-1">
                        Utilizing smart contracts on the Stellar network, Wagering.gg can
                        award funds directly between accounts and can create complex payment
                        scenarios. Imagine a scenario where 100 people enter a tournament with
                        money and the top players earn some of the pool. With smart contracts,
                        this is possible.
                    </v-expansion-panel-content>
                </v-expansion-panel>
                <v-expansion-panel>
                    <v-expansion-panel-header class="headline">How much are service fees?</v-expansion-panel-header>
                    <v-expansion-panel-content class="body-1">
                        Our service fee is 10% - or 5% for verified users - of the loser's
                        wager amount. A standard percentage rate keeps the process simple and
                        allows for low-value wagers to be possible. This still keeps our fees
                        close to traditional methods while being able to provide a service.
                    </v-expansion-panel-content>
                </v-expansion-panel>
            </v-expansion-panels>
        </v-container>
        <v-container>
            <h1 class="display-2">
                <v-icon large color="accent">mdi-pound</v-icon>
                Resources
            </h1>
        </v-container>
        <v-container>
            <h3 class="display-1">
                <v-icon large color="accent">mdi-pound</v-icon>
                <v-icon large color="accent">mdi-pound</v-icon>
                Exchanges
            </h3>
        </v-container>
        <v-container>
            <v-btn color="secondary" outlined target="_blank" href="https://www.stellarx.com/">StellarX</v-btn>
            <v-btn color="secondary"
                   outlined
                   target="_blank"
                   href="https://www.coinbase.com/join/lopez_rdfi">Coinbase</v-btn>
            <v-btn color="secondary"
                   outlined
                   target="_blank"
                   href="https://pro.coinbase.com/">Coinbase Pro</v-btn>
            <v-btn color="secondary" outlined target="_blank" href="https://shapeshift.io/">Shapeshift</v-btn>
        </v-container>
        <v-container>
            <h3 class="display-1">
                <v-icon large color="accent">mdi-pound</v-icon>
                <v-icon large color="accent">mdi-pound</v-icon>
                Earning
            </h3>
        </v-container>
        <v-container>
            <v-btn color="secondary" outlined target="_blank" href="https://brave.com/?ref=ism355">Brave</v-btn>
            <v-btn color="secondary" outlined target="_blank" href="https://bounty0x.io/">Bounty0x</v-btn>
        </v-container>
    </v-container>
</template>
<script>
    export default {};
</script>
