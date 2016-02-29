module Dashboard.Resources {
    export interface IServerResourceDefn extends ng.resource.IResource<Models.IServer>{
        
    }

    export interface IServerResource extends ng.resource.IResourceClass<IServerResourceDefn> {
        
    }
}