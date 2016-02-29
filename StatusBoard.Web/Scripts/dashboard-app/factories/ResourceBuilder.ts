module Dashboard.Factories {
    export class ResourceBuilder {
        static $inject = ["$resource"];

        constructor(private $resource: ng.resource.IResourceService) {
            
        }

        public getServerResource(): Resources.IServerResource {
            return this.$resource("/api/Servers/:id", {id : "@id"}, {});
        }
    }

    angular.module("dashboard").factory("ResourceBuilder", ["$resource", ($resource) => new Factories.ResourceBuilder($resource)]);
}