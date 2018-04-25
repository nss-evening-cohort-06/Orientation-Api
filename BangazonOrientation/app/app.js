﻿var app = angular.module("StillNotQuiteHuman", ["ngRoute"]);

app.config([
    '$routeProvider', function ($routeProvider) {
        $routeProvider
            .when("/",
                {
                    templateUrl: '/app/partials/index.html',
                    controller: 'HomeController'
                });
    }
]);