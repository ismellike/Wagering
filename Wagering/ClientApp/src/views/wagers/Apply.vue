<template>
    <content-display>
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
                                                v-if="index == -1"
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
                                                :value="profile.displayName"
                                            ></v-text-field>
                                        </v-col>
                                        <v-col cols="6" sm="3">
                                            <v-text-field
                                                v-model="user.payablePt"
                                                label="Payable (%)"
                                                type="number"
                                                append-icon="mdi-percent"
                                            ></v-text-field>
                                        </v-col>
                                        <v-col cols="6" sm="3">
                                            <v-text-field
                                                v-model="user.receivablePt"
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
                        >{{ item.receivablePt }}</v-progress-circular
                    >
                </template>
                <template v-slot:item.payablePt="{ item }">
                    <v-progress-circular
                        :value="item.payablePt"
                        class="overline"
                        >{{ item.payablePt }}</v-progress-circular
                    >
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
    </content-display>
</template>
<script lang="ts">
import Vue from "vue";

export default Vue.extend({});
</script>
