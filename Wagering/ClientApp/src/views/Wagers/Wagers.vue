<template>
    <div class="hero-body is-block">
    <div class="container">
        <h1 class="title has-text-centered">Wagers</h1>
        <div class="level is-mobile">
            <div class="level-left">
                <div class="level-item">
                    <h4 class="subtitle">Page @Query.Page</h4>
                </div>
            </div>
            <div class="level-right">
                <div class="level-item pointer" @onclick="ToggleFilter">
                    <span>Filter</span>
                    <span class="icon">
                        @if (ShowFilter)
                        {
                            <img src=".../assets/icons/expand_less.svg" />
                        }
                        else
                        {
                            <img src=".../assets/icons/expand_more.svg" />
                        }
                    </span>
                </div>
            </div>
        </div>
            <form v-if="showFilter">
                <div class="columns">
                    <div class="column">
                        <div class="field">
                            <label class="label" for="username">Search Username:</label>
                            <div class="control has-icons-left">
                                <InputText id="username" class="input" @bind-Value="Query.Username" />
                                <span class="icon is-left">
                                    <img src=".../assets/icons/account.svg" />
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="column">
                        <div class="field">
                            <label class="label" id="count">Player Count:</label>
                            <div class="control has-icons-left">
                                <InputNumber id="count" class="input" @bind-Value="Query.PlayerCount" />
                                <span class="icon is-left">
                                    <img src=".../assets/icons/people.svg" />
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="column">
                        <div class="field">
                            <label class="label" id="minimum">Minimum Wager:</label>
                            <div class="control has-icons-left has-icons-right">
                                <InputNumber id="minimum" class="input" @bind-Value="Query.MinimumWager" />
                                <span class="icon is-left">
                                    <img src=".../assets/icons/lumens.png" />
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="column">
                        <div class="field">
                            <label class="label" id="maximum">Maximum Wager:</label>
                            <div class="control has-icons-left">
                                <InputNumber id="maximum" class="input" @bind-Value="Query.MaximumWager" />
                                <span class="icon is-left">
                                    <img src=".../assets/icons/lumens.png" />
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="level is-mobile mb-1">
                    <div class="level-left">
                    </div>
                    <div class="level-right">
                        <div class="level-item">
                            <div class="field">
                                <InputCheckbox id="closed" class="switch" @bind-Value="Query.ShowClosed" />
                                <label for="closed">Show Closed</label>
                            </div>
                        </div>
                        <div class="level-item">
                            <button type="submit" :disabled="isLocked" class="button is-primary">Submit</button>
                        </div>
                    </div>
                </div>
            </form>
            <Loading v-if="wagers === null" />
            <div v-else>
                <div v-for="wager in wagers" v-bind:key="wager.id">
                    <WagerDisplay :wager="wager" />
                </div>
                <div class="level is-mobile">
                    <div class="level-left">
                    </div>
                    <div class="level-right">
                        <div class="level-item">
                            @if (PagedWagers.HasPreviousPage())
                            {
                                <button class="button is-primary" @onclick="Previous">Previous</button>
                            }
                        </div>
                        <div class="level-item">
                            @if (PagedWagers.HasNextPage())
                            {
                                <button class="button is-primary" @onclick="Next">Next</button>
                            }
                        </div>
                    </div>
                </div>
            </div>
    </div>
</div>
</template>
<script>
import Loading from '.../components/Loading'
import WagerDisplay from '.../components/WagerDisplay'
export default { 
    components: {
        Loading
    },
    props: {
        game: {
            type: String,
            required: true
        }
    },
    data(){
        return{
            query: {
                username: String,
                game: this.game.toLowerCase(),
                page: 1,
                playerCount: Number,
                showClosed: false,
                minimumWager: Number,
                maximumWager: Number
            },
            wagers:{
                //map
            },
            showFilter: false,
            isLocked: false,
            errors: []
        };
    },
    mutations:{
        toggleFilter(){
            this.showFilter = !this.showFilter;
        },
        async previous(){
            this.query.page--;
            await getWagers();
        },
        async next(){
            this.query.page++;
            await getWagers();
        },
        async getWagers(){
            this.isLocked = true;
            //validate query
            //api call here 
            this.isLocked = false;
        }
    }
}
</script>