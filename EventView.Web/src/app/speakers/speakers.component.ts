import { CanActivate, ChangeDetectionStrategy, Component } from "angular-rx-ui/src/components/core";

@Component({
    template: require("./speakers.component.html"),
    styles: [require("./speakers.component.scss")],
    selector: "speakers",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SpeakersComponent {
    constructor() { }
}
