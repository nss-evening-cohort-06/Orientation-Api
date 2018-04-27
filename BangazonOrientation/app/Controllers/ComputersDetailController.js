app.controller("ComputersDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        $scope.refuse = false;

        $http.get(`/api/computers/${$routeParams.id}`).then(function (result) {
            $scope.computer = result.data;
        });

        $scope.back = () => {
            $location.path(`/computers`);
        };

        $scope.firstdelete = () => {

            // get the employee Computer join table by the ComputerID
            $http.get(`/api/EmployeeComputers/${$routeParams.id}`).then((employeeComputerData) => {

                // if it comes back null the id was not found, so the user can see the final delete page
                if (employeeComputerData.data == null) {
                    return toDelete();
                }

                // if a result comes back with a computerID that means that computer has been assigned before so it cannot be deleted, as per project specs
                return $scope.refuse = true;
            });
        };

        const toDelete = () => {
            $location.path(`/computers/${$routeParams.id}/delete`);
        }

    }
]);