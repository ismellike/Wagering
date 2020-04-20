<template>
    <v-card>
        <v-toolbar dense color="accent">
            <v-toolbar-title>{{ hostsString }}</v-toolbar-title>
            <v-spacer />
            <v-btn color="secondary"
                   v-if="code == 1"
                   :to="{ name: 'wager_view', params: { game: wager.gameName, id: wager.id } }"
                   class="mr-2">View</v-btn>
            <v-btn color="secondary"
                   v-else-if="code == 2"
                   :to="{ name: 'wager_pending', params: { id: wager.id } }"
                   class="mr-2">
                View
            </v-btn>
            <v-menu>
                <template v-slot:activator="{ on }">
                    <v-btn color="info" v-on="on">Hosts</v-btn>
                </template>
                <v-list>
                    <v-list-item v-for="host in wager.hosts" :key="host.id">
                        <v-list-item-title>
                            <v-btn color="secondary"
                                   :to="{ name:'user_view', params:{name:host.user.userName}}"
                                   class="ma-1">{{ host.user.userName }}</v-btn>
                        </v-list-item-title>
                    </v-list-item>
                </v-list>
            </v-menu>
        </v-toolbar>
        <v-card-text>
            <WagerInfoDisplay :wager="wager" />
        </v-card-text>
        <v-card-actions>
            <v-spacer />
            <span class="caption">
                {{ $timeAgo.format(new Date(wager.date)) }}
            </span>
        </v-card-actions>
    </v-card>
</template>
<script>
    import WagerInfoDisplay from "@/components/WagerInfoDisplay";
    export default {
        components: {
            WagerInfoDisplay
        },
        props: {
            wager: {
                required: true
            },
            code: {
                type: Number,
                default: 0
            }
        },
        computed: {
            hostsString() {
                const cutoff = 4;
                if (this.wager == null || this.wager.hosts == null)
                    return null;
                const length = this.wager.hosts.length;
                const hosts = this.wager.hosts.slice();
                if (length > cutoff) {
                    return (
                        hosts
                            .splice(0, cutoff)
                            .map(x => x.user.userName)
                            .join(", ") +
                        ", +" +
                        (length - cutoff + 1) +
                        " more..."
                    );
                }
                return hosts.map(x => x = x.user.userName).join(", ");
            }
        }
    };
</script>
