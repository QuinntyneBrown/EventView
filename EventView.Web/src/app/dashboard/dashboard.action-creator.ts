import { IDispatcher, BaseActionCreator, Service } from "angular-rx-ui/src/components/core";
import { ModalActionCreator } from "angular-rx-ui/src/components/modal/modal.action-creator";

@Service({
    serviceName: "dashboardActionCreator",
    viewProviders: ["dispatcher", "guid", "invokeAsync","modalActionCreator"]
})
export class DashboardActionCreator {
    constructor(private dispatcher: IDispatcher, private guid, private invokeAsync, private modalActionCreator: ModalActionCreator) { }    

}



