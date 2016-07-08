describe("appHeader", () => {

    var appHeaderComponent;
    var $compile;
    var $rootScope;

    class MockActionCreator { }

    beforeEach(() => {
        angular.mock.module("eventViewApp.shared");
    });

    beforeEach(inject(($controller, _$compile_, _$rootScope_) => {
        $rootScope = _$rootScope_;
        $compile = _$compile_;
        appHeaderComponent = $controller("appHeaderComponent", { appHeaderActionCreator: new MockActionCreator() });
    }));

    it("should compile", () => {
        var element = $compile("<app-header></app-header>")($rootScope);
        expect(element).toBeDefined();
    });

    it("should be defined", () => {
        expect(appHeaderComponent).toBeDefined();
    });
})
