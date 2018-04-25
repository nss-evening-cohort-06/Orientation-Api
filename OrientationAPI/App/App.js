var app = angular.module("OrientationAPI", ["ngRoute"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "/app/partials/home.html",
            controller: "HomeController"
        })
        .when("/employees", {
            templateUrl: "/app/partials/Employees.html",
            controller: "EmployeesController"
        })
        .otherwise('/');
}]);