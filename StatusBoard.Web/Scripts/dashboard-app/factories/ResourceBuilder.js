var Dashboard;
(function (Dashboard) {
    var Factories;
    (function (Factories) {
        var ResourceBuilder = (function () {
            function ResourceBuilder($resource) {
                this.$resource = $resource;
            }
            ResourceBuilder.prototype.getServerResource = function () {
                return this.$resource("/api/Servers/:id", { id: "@id" }, {});
            };
            ResourceBuilder.$inject = ["$resource"];
            return ResourceBuilder;
        })();
        Factories.ResourceBuilder = ResourceBuilder;
        angular.module("dashboard").factory("ResourceBuilder", ["$resource", function ($resource) { return new Factories.ResourceBuilder($resource); }]);
    })(Factories = Dashboard.Factories || (Dashboard.Factories = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=ResourceBuilder.js.map