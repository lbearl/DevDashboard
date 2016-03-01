/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
/// <reference path="../../../typings/browser/ambient/angular-resource/angular-resource.d.ts" />
"use strict";

module Dashboard.Services {
    import ResourceBuilder = Dashboard.Factories.ResourceBuilder;
    import Service = Interfaces.IServerService;

    export class ServerService implements Service {
        static $inject = ["ResourceBuilder"];

        private serverResource;
        constructor(private builder: ResourceBuilder) {
            this.serverResource = builder.getServerResource();
        }

        public getServers() {
            return this.serverResource.query();
        }


    }
    angular.module("dashboard").factory("ServerService", ["ResourceBuilder", (resourceBuilder) => new ServerService(resourceBuilder)]);
}