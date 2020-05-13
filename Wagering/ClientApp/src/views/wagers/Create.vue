<template>
    <content-display>
        <error-display :error="error" />
        <v-container>
            <v-data-table
                :headers="headers"
                :items="wager.hosts"
                hide-default-footer
            >
                <template v-slot:top>
                    <v-toolbar color="accent">
                        <v-toolbar-title>Members</v-toolbar-title>
                        <v-spacer></v-spacer>
                        <v-dialog v-model="dialog" max-width="500px">
                            <template v-slot:activator="{ on }">
                                <v-btn color="secondary" v-on="on"
                                    >Add User</v-btn
                                >
                            </template>
                            <v-card>
                                <v-card-title>{{ dialogTitle }}</v-card-title>
                                <v-card-text>
                                    <v-row>
                                        <v-col cols="12" sm="6">
                                            <v-autocomplete
                                                v-if="index"
                                                v-model="search.select"
                                                :loading="search.loading"
                                                :items="search.users"
                                                :search-input.sync="searchEvent"
                                                cache-items
                                                hide-no-data
                                                clearable
                                                label="User Name"
                                                item-text="profile.displayName"
                                                return-object
                                            ></v-autocomplete>
                                            <v-text-field
                                                disabled
                                                v-else
                                                label="User Name"
                                                :value="bid.profile.displayName"
                                            ></v-text-field>
                                        </v-col>
                                        <v-col cols="6" sm="3">
                                            <v-text-field
                                                v-model="bid.payablePt"
                                                label="Payable (%)"
                                                type="number"
                                                append-icon="mdi-percent"
                                            ></v-text-field>
                                        </v-col>
                                        <v-col cols="6" sm="3">
                                            <v-text-field
                                                v-model="bid.receivablePt"
                                                label="Receivable (%)"
                                                type="number"
                                                append-icon="mdi-percent"
                                            ></v-text-field>
                                        </v-col>
                                    </v-row>
                                </v-card-text>

                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="success" @click="save"
                                        >Save</v-btn
                                    >
                                    <v-btn color="error" @click="close"
                                        >Cancel</v-btn
                                    >
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                    </v-toolbar>
                </template>
                <template v-slot:item.actions="{ item }">
                    <v-icon
                        small
                        color="warning"
                        class="mr-2"
                        @click="editUser(item)"
                        >mdi-pencil</v-icon
                    >
                    <v-icon
                        v-if="!item.isOwner"
                        small
                        color="error"
                        @click="deleteUser(item)"
                        >mdi-delete</v-icon
                    >
                </template>
                <template v-slot:item.approved="{ item }">
                    <v-simple-checkbox
                        v-model="item.approved"
                        disabled
                    ></v-simple-checkbox>
                </template>
                <template v-slot:item.receivablePt="{ item }">
                    <v-progress-circular
                        :value="item.receivablePt"
                        class="overline"
                    >
                        {{ item.receivablePt }}
                    </v-progress-circular>
                </template>
                <template v-slot:item.payablePt="{ item }">
                    <v-progress-circular
                        :value="item.payablePt"
                        class="overline"
                    >
                        {{ item.payablePt }}
                    </v-progress-circular>
                </template>
                <template v-slot:footer>
                    <v-simple-table>
                        <table>
                            <tbody>
                                <tr>
                                    <td class="overline">Total:</td>
                                    <td>
                                        <v-progress-circular
                                            :color="payableColor"
                                            :value="totalPayable"
                                            class="overline"
                                            >{{
                                                totalPayable
                                            }}</v-progress-circular
                                        >
                                    </td>
                                    <td>
                                        <v-progress-circular
                                            :color="receivableColor"
                                            :value="totalReceivable"
                                            class="overline"
                                            >{{
                                                totalReceivable
                                            }}</v-progress-circular
                                        >
                                    </td>
                                    <td class="text-right">
                                        <v-btn
                                            small
                                            outlined
                                            color="secondary"
                                            @click="normalize"
                                            >Normalize</v-btn
                                        >
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </v-simple-table>
                </template>
            </v-data-table>
        </v-container>
        <v-container>
            <validation-observer v-slot="{ handleSubmit }">
                <form @submit.prevent="handleSubmit(submit)">
                    <v-card>
                        <v-card-title>Settings</v-card-title>
                        <v-card-text>
                            <v-row>
                                <v-col cols="12" sm="6" md="3">
                                    <validation-provider
                                        rules="less_than:@maxWager|min_value:.001"
                                        vid="minWager"
                                        name="Minimum Wager"
                                        v-slot="{ errors }"
                                    >
                                        <v-text-field
                                            v-model="wager.minimumWager"
                                            label="Minimum Wager"
                                            :error-messages="errors"
                                        ></v-text-field>
                                    </validation-provider>
                                </v-col>
                                <v-col cols="12" sm="6" md="3">
                                    <validation-provider
                                        rules="greater_than:@minWager|min_value:.001"
                                        vid="maxWager"
                                        name="Maximum Wager"
                                        v-slot="{ errors }"
                                    >
                                        <v-text-field
                                            v-model="wager.maximumWager"
                                            label="Maximum Wager"
                                            :error-messages="errors"
                                        ></v-text-field>
                                    </validation-provider>
                                </v-col>
                                <v-col cols="12" md="6">
                                    <validation-provider
                                        rules="min:5|max:50"
                                        name="Description"
                                        v-slot="{ errors }"
                                    >
                                        <v-textarea
                                            v-model="wager.description"
                                            label="Description"
                                            counter="50"
                                            rows="1"
                                            :error-messages="errors"
                                        ></v-textarea>
                                    </validation-provider>
                                </v-col>
                            </v-row>
                        </v-card-text>
                        <v-card-actions>
                            <v-switch
                                v-model="wager.isPrivate"
                                label="Private"
                            ></v-switch>
                            <v-spacer />
                            <v-btn color="success" type="submit">Create</v-btn>
                        </v-card-actions>
                    </v-card>
                </form>
            </validation-observer>
        </v-container>
    </content-display>
</template>
<script lang="ts">
import Vue from "vue";
import { AxiosResponse, AxiosError } from "axios";
import { RawLocation } from "vue-router";

interface Search {
    users: Profile[];
    displayName: string | null;
    interval: number;
    loading: boolean;
    select: Profile | null;
    timer: NodeJS.Timer | null;
}

export default Vue.extend({
    data() {
        return {
            searchEvent: null,
            wager: {
                gameId: this.$games.getId(this.$route.params.game),
                isPrivate: false,
                hosts: [
                    {
                        profileId: this.$store.getters.id,
                        profile: {
                            displayName: this.$store.getters.displayName
                        },
                        approved: true,
                        receivablePt: 100,
                        payablePt: 100,
                        isOwner: true
                    }
                ]
            } as Wager,
            search: {
                users: [],
                displayName: null,
                interval: 500,
                loading: false,
                select: null,
                timer: null
            } as Search,
            bid: {
                profile: {
                    displayName: undefined
                },
                profileId: undefined,
                approved: false,
                receivablePt: 50,
                payablePt: 50,
                isOwner: false
            } as WagerHostBid,
            defaultBid: {
                profile: {
                    displayName: undefined
                },
                profileId: undefined,
                approved: false,
                receivablePt: 50,
                payablePt: 50,
                isOwner: false
            } as WagerHostBid,
            index: null as number | null,
            dialog: false as boolean,
            headers: [
                {
                    text: "User Name",
                    align: "start",
                    value: "profile.displayName"
                },
                { text: "Payable (%)", value: "payablePt" },
                { text: "Receivable (%)", value: "receivablePt" },
                { text: "Approved", value: "approved" },
                { text: "Actions", value: "actions", sortable: false }
            ],
            error: null as AxiosError | null
        };
    },
    watch: {
        searchEvent(val: string): void {
            if (this.search.timer) clearTimeout(this.search.timer);
            if (
                val &&
                val.trim() &&
                val !== this.search.select &&
                this.search.displayName != val
            ) {
                this.search.displayName = val;
                this.search.loading = true;
                this.search.timer = setTimeout(
                    this.getUsers,
                    this.search.interval
                );
            } else {
                if (this.search.timer) clearTimeout(this.search.timer);
                this.search.loading = false;
            }
        }
    },
    computed: {
        totalReceivable(): number {
            return (
                this.wager?.hosts?.reduce(
                    (x: number, y: WagerHostBid) => x + y.receivablePt,
                    0
                ) ?? 0
            );
        },
        receivableColor(): string {
            return this.totalReceivable == 100 ? "success" : "error";
        },
        totalPayable(): number {
            return (
                this.wager?.hosts?.reduce(
                    (x: number, y: WagerHostBid) => x + y.payablePt,
                    0
                ) ?? 0
            );
        },
        payableColor(): string {
            return this.totalPayable == 100 ? "success" : "error";
        },
        dialogTitle(): string {
            return this.index ? "Add User" : "Edit User";
        }
    },
    methods: {
        getUsers(): void {
            this.$axios
                .get("/api/user/search/" + this.search.displayName)
                .then((response: AxiosResponse) => {
                    this.search.users = response.data;
                })
                .finally(() => {
                    this.search.loading = false;
                });
        },
        close(): void {
            this.bid = Object.assign({}, this.defaultBid);
            this.dialog = false;
            this.search.select = null;
            this.index = null;
        },
        addUser(): void {
            if (this.search.select) {
                if (
                    this.wager?.hosts?.some((x: WagerHostBid) => {
                        if (x.profile && this.bid.profile)
                            return (
                                x.profile.displayName ==
                                this.bid.profile.displayName
                            );
                    })
                ) {
                    this.wager.hosts.push({
                        profile: {
                            displayName: this.search.select.displayName
                        },
                        profileId: this.search.select.id,
                        approved: false,
                        payablePt: this.bid.payablePt,
                        receivablePt: this.bid.receivablePt,
                        isOwner: false
                    });
                }
            }
        },
        save(): void {
            if (this.index) {
                if (this.wager && this.wager.hosts)
                    Object.assign(this.wager.hosts[this.index], this.bid);
            } else {
                this.addUser();
            }
            this.close();
        },
        editUser(item: WagerHostBid): void {
            this.index = this.wager?.hosts?.indexOf(item) ?? null;
            this.bid = {
                ...item
            };
            this.dialog = true;
        },
        deleteUser(item: WagerHostBid): void {
            if (this.wager && this.wager.hosts) {
                const index = this.wager.hosts.indexOf(item);
                if (index > -1)
                    confirm("Are you sure you want to remove this user?") &&
                        this.wager.hosts.splice(index, 1);
            }
        },
        normalize(): void {
            if (!this.wager || !this.wager.hosts) return;
            const count = this.wager.hosts.length;
            this.wager.hosts.forEach((item: WagerHostBid) => {
                const amount = Math.floor(100 / count);
                item.receivablePt = amount;
                item.payablePt = amount;
            });
        },
        submit(): void {
            this.postWager();
        },
        postWager(): void {
            this.$axios
                .post("/api/wager", this.wager)
                .then((response: AxiosResponse) => {
                    this.$microsoft.signalr.invoke(
                        "AddToGroup",
                        response.data.groupName
                    );
                    if (response.data.others.length > 0)
                        this.$microsoft.signalr.invoke(
                            "AddUsersToGroup",
                            response.data.groupName,
                            response.data.others,
                            response.data.notification
                        );
                    const pathName =
                        response.data.wager.status == 1
                            ? "wager_confirmed"
                            : "wager_pending";
                    this.$router.push({
                        name: pathName,
                        params: { id: response.data.id }
                    } as RawLocation);
                })
                .catch((e: AxiosError) => {
                    this.error = e;
                });
        }
    }
});
</script>
