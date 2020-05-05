<template>
  <v-container>
    <v-row dense>
      <v-col cols="12" sm="10" md="8" class="mx-auto">
        <v-data-table :headers="headers" :items="wager.hosts" hide-default-footer>
          <template v-slot:top>
            <v-toolbar color="accent">
              <v-toolbar-title>Members</v-toolbar-title>
              <v-spacer></v-spacer>
              <v-dialog v-model="dialog" max-width="500px">
                <template v-slot:activator="{ on }">
                  <v-btn color="secondary" v-on="on">Add User</v-btn>
                </template>
                <v-card>
                  <v-card-title>
                    {{
                    dialogTitle
                    }}
                  </v-card-title>
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
                          label="Username"
                          item-text="userName"
                          return-object
                        ></v-autocomplete>
                        <v-text-field disabled v-else label="Username" :value="user.userName"></v-text-field>
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
                    <v-btn color="success" @click="save">Save</v-btn>
                    <v-btn color="error" @click="close">Cancel</v-btn>
                  </v-card-actions>
                </v-card>
              </v-dialog>
            </v-toolbar>
          </template>
          <template v-slot:item.actions="{ item }">
            <v-icon small color="warning" class="mr-2" @click="editUser(item)">mdi-pencil</v-icon>
            <v-icon v-if="!item.isOwner" small color="error" @click="deleteUser(item)">mdi-delete</v-icon>
          </template>
          <template v-slot:item.approved="{ item }">
            <v-simple-checkbox v-model="item.approved" disabled></v-simple-checkbox>
          </template>
          <template v-slot:item.receivablePt="{ item }">
            <v-progress-circular :value="item.receivablePt" class="overline">{{ item.receivablePt }}</v-progress-circular>
          </template>
          <template v-slot:item.payablePt="{ item }">
            <v-progress-circular :value="item.payablePt" class="overline">{{ item.payablePt }}</v-progress-circular>
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
                      >
                        {{
                        totalPayable
                        }}
                      </v-progress-circular>
                    </td>
                    <td>
                      <v-progress-circular
                        :color="receivableColor"
                        :value="totalReceivable"
                        class="overline"
                      >
                        {{
                        totalReceivable
                        }}
                      </v-progress-circular>
                    </td>
                    <td class="text-right">
                      <v-btn small outlined color="secondary" @click="normalize">Normalize</v-btn>
                    </td>
                  </tr>
                </tbody>
              </table>
            </v-simple-table>
          </template>
        </v-data-table>
      </v-col>
      <v-col cols="12" sm="10" md="8" class="mx-auto">
        <v-card>
          <v-card-title>Settings</v-card-title>
          <v-card-text>
            <ValidationObserver ref="observer">
              <v-row>
                <v-col cols="12" sm="6" md="3">
                  <ValidationProvider
                    rules="less_than:@maxWager|min_amount"
                    vid="minWager"
                    name="Minimum Wager"
                    v-slot="{ errors }"
                  >
                    <v-text-field
                      v-model="wager.minimumWager"
                      label="Minimum Wager"
                      type="number"
                      :error-messages="errors"
                    ></v-text-field>
                  </ValidationProvider>
                </v-col>
                <v-col cols="12" sm="6" md="3">
                  <ValidationProvider
                    rules="greater_than:@minWager|min_amount"
                    vid="maxWager"
                    name="Maximum Wager"
                    v-slot="{ errors }"
                  >
                    <v-text-field
                      v-model="wager.maximumWager"
                      label="Maximum Wager"
                      type="number"
                      :error-messages="errors"
                    ></v-text-field>
                  </ValidationProvider>
                </v-col>
                <v-col cols="12" md="6">
                  <v-textarea v-model="wager.description" label="Description" rows="1"></v-textarea>
                </v-col>
              </v-row>
            </ValidationObserver>
          </v-card-text>
          <v-card-actions>
            <v-switch v-model="wager.isPrivate" label="Private"></v-switch>
            <v-spacer />
            <v-btn color="success" v-on:click="submit">Create</v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>
<script lang="ts">
import { AxiosResponse } from "axios";

interface UserBid {
  userName: string;
  userId: number;
  approved: boolean;
  receivablePt: number;
  payablePt: number;
  isOwner: boolean;
}

interface Search {
  users: ApplicationUser[];
  userName: string;
  interval: number;
  loading: boolean;
  select: ApplicationUser;
  timer: NodeJS.Timer;
}

export default {
  data() {
    return {
      searchEvent: null as void,
      wager: {
        gameUrl: this.$route.params.game.toLowerCase(),
        minimumWager: null,
        maximumWager: null,
        description: null,
        isPrivate: false,
        hosts: [
          {
            user: {
              userName: this.$store.getters.username
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
        userName: null,
        interval: 500,
        loading: false,
        select: null,
        timer: null
      } as Search,
      user: {
        userName: null,
        userId: null,
        approved: false,
        receivablePt: 50,
        payablePt: 50,
        isOwner: false
      } as UserBid,
      defaultUser: {
        userName: null,
        userId: null,
        approved: false,
        receivablePt: 50,
        payablePt: 50,
        isOwner: false
      } as UserBid,
      index: -1 as number,
      dialog: false as boolean,
      headers: [
        {
          text: "Username",
          align: "start",
          value: "userName"
        },
        { text: "Payable (%)", value: "payablePt" },
        { text: "Receivable (%)", value: "receivablePt" },
        { text: "Approved", value: "approved" },
        { text: "Actions", value: "actions", sortable: false }
      ]
    };
  },
  watch: {
    searchEvent(val: string): void {
      clearTimeout(this.search.timer);
      if (
        val &&
        val.trim() &&
        val !== this.search.select &&
        this.search.userName != val
      ) {
        this.search.userName = val;
        this.search.loading = true;
        this.search.timer = setTimeout(this.getUsers, this.search.interval);
      } else {
        clearTimeout(this.search.timer);
        this.search.loading = false;
      }
    }
  },
  computed: {
    totalReceivable(): number {
      return this.wager.hosts.reduce(
        (x: number, y: WagerHostBid) => x + y.receivablePt,
        0
      );
    },
    receivableColor(): string {
      return this.totalReceivable == 100 ? "success" : "error";
    },
    totalPayable(): number {
      return this.wager.hosts.reduce(
        (x: number, y: WagerHostBid) => x + y.payablePt,
        0
      );
    },
    payableColor(): string {
      return this.totalPayable == 100 ? "success" : "error";
    },
    dialogTitle(): string {
      return this.index == -1 ? "Add User" : "Edit User";
    }
  },
  methods: {
    getUsers(): void {
      this.$axios
        .get("/api/user/search/" + this.search.userName)
        .then((response: AxiosResponse) => {
          this.search.users = response.data;
        })
        .finally(() => {
          this.search.loading = false;
        });
    },
    close(): void {
      this.user = Object.assign({}, this.defaultUser);
      this.dialog = false;
      this.search.select = null;
      this.index = -1;
    },
    addUser(): void {
      if (this.search.select) {
        if (
          !this.wager.hosts.some((x: WagerHostBid) => {
            return x.user.userName == this.username;
          })
        ) {
          this.wager.hosts.push({
            userName: this.search.select.userName,
            userId: this.search.select.id,
            approved: false,
            payablePt: this.user.payablePt,
            receivablePt: this.user.receivablePt
          });
        }
      }
    },
    save(): void {
      if (this.index > -1) {
        Object.assign(this.wager.hosts[this.index], this.user);
      } else {
        this.addUser();
      }
      this.close();
    },
    editUser(item: WagerHostBid): void {
      this.index = this.wager.hosts.indexOf(item);
      this.user = Object.assign({}, item);
      this.dialog = true;
    },
    deleteUser(item: WagerHostBid): void {
      const index = this.wager.hosts.indexOf(item);
      confirm("Are you sure you want to remove this user?") &&
        this.wager.hosts.splice(index, 1);
    },
    normalize(): void {
      const count = this.wager.hosts.length;
      this.wager.hosts.forEach((item: WagerHostBid) => {
        const amount = Math.floor(100 / count);
        item.receivablePt = amount;
        item.payablePt = amount;
      });
    },
    submit(): void {
      this.$refs.observer.validate().then((response: AxiosResponse) => {
        if (response) {
          this.postWager();
        }
      });
    },
    postWager(): void {
      this.$axios
        .post("/api/wager", this.wager)
        .then((response: AxiosResponse) => {
          this.$microsoft.signalr.invoke("AddToGroup", response.data.groupName);
          const users = response.data.hosts
            .filter((x: WagerHostBid) => !x.isOwner)
            .map((x: WagerHostBid) => x.userId);
          if (users.length > 0)
            this.$microsoft.signalr.invoke(
              "AddUsersToGroup",
              response.data.groupName,
              users,
              {
                message:
                  this.$store.getters.username +
                  " created a new wager with you.",
                isRead: false,
                link: "/host/wagers/pending/" + response.data.id
              }
            );
          const pathName =
            response.data.status == 1 ? "wager_confirmed" : "wager_pending";
          this.$router.push({
            name: pathName,
            params: { id: response.data.id }
          });
        });
    }
  }
};
</script>
