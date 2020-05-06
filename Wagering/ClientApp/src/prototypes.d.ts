import Vue from "vue";
import { AxiosInstance } from "axios";
import VueRouter, { Route } from "vue-router";
import { HubConnection } from "@microsoft/signalr";
import { Store } from "vuex";

declare module "vue/types/vue" {
    interface SignalR {
        signalr: HubConnection;
    }
    interface Vue {
        $axios: AxiosInstance;
        $router: VueRouter;
        $route: Route;
        $microsoft: SignalR;
        $store: Store<any>;
    }
}
