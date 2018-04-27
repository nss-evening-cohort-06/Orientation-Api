app.controller("ComputersDeleteController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $http.get(`/api/computers/${$routeParams.id}`).then(function (result) {
            $scope.computer = result.data;
        });

        $scope.back = () => {
            $location.path(`/computers/${$routeParams.id}`);
        };

        $scope.theyReallyWantToDeleteThis = () => {
            $http.delete(`/api/computers/${$routeParams.id}`).then(function (result) {
                $location.path(`/computers`);
            });
        };
    }
]);