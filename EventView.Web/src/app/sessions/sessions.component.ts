import { CanActivate, ChangeDetectionStrategy, Component } from "angular-rx-ui/src/components/core";

@Component({
    template: require("./sessions.component.html"),
    styles: [require("./sessions.component.scss")],
    selector: "sessions",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SessionsComponent { }
