import Vue from "vue";
import { AxiosInstance } from "axios";
import VueRouter, { Route } from "vue-router";
import { HubConnection } from "@microsoft/signalr";

declare module "*.vue" {
  export default Vue;
}

declare module "vue/types/vue" {
  interface SignalR {
    signalr: HubConnection;
  }
  interface Vue {
    $axios: AxiosInstance;
    $router: VueRouter;
    $route: Route;
    $microsoft: SignalR;
  }
}
