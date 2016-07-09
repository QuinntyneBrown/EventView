import { CanActivate, ChangeDetectionStrategy, Component } from "angular-rx-ui/src/components/core";

@Component({
    template: require("./session-card.component.html"),
    styles: [require("./session-card.component.scss")],
    selector: "session-card",
    inputs:["@title","@date","@time","@speaker","@timeSlot","@location"],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SessionCardComponent { }
