declare module Dashboard.Factories {
    class ResourceBuilder {
        private $resource;
        static $inject: string[];
        constructor($resource: ng.resource.IResourceService);
        getServerResource(): Resources.IServerResource;
    }
}
