describe("appFooter", () => {

    var appFooterComponent;
    var $compile;
    var $rootScope;

    class MockActionCreator { }

    beforeEach(() => {
        angular.mock.module("eventViewApp.shared");
    });

    beforeEach(inject(($controller, _$compile_, _$rootScope_) => {
        $rootScope = _$rootScope_;
        $compile = _$compile_;
        appFooterComponent = $controller("appFooterComponent", { appFooterActionCreator: new MockActionCreator() });
    }));

    it("should compile", () => {
        var element = $compile("<app-footer></app-footer>")($rootScope);
        expect(element).toBeDefined();
    });

    it("should be defined", () => {
        expect(appFooterComponent).toBeDefined();
    });
})
