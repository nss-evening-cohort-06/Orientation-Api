app.controller("ComputersDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $scope.toDelete = false;
        $scope.refuse = false;

        $http.get(`/api/computers/${$routeParams.id}`).then(function (result) {
            $scope.computer = result.data;
        });

        $scope.back = () => {
            $location.path(`/computers`);
        };

        $scope.firstdelete = () => {

            // check the join table,
            //$http.get(`/api/EmployeeComputer/${$routeParams.id}`).then(function (result) {

            //    // if a truthy result comes back that means that id exists so it cannot be deleted, as per project specs
            //    // if it comes back falsy the id was not found, so the user can see the final delete button
            //    result ? $scope.refuse = true : $scope.toDelete = true;
            //});
            $scope.toDelete = true;
        };

        $scope.theyReallyWantToDeleteThis = () => {
            $http.delete(`/api/computers/${$routeParams.id}`).then(function (result) {
                $location.path(`/computers`);
            });
        };
    }
]);