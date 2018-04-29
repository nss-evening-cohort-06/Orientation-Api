app.controller("EmployeeDetailController", ["$location", "$routeParams", "$scope", "$http",
    function ($location, $routeParams, $scope, $http) {

        var hasComputer = true;

        $http.get(`/api/employees/${$routeParams.id}`).then((result) => {
            $scope.employee = result.data;
        });

        // check the employeeComputer table for an employeeID that matches the current employee selected
        $http.get(`/api/EmployeeComputers/${$routeParams.id}/employee`).then((result) => {
            // if the result comes back empty give the user a message that they don't have a computer assigned right now
            if (result === null) {
                return hasComputer = false;
            }

            var employeeComputer = result.data;

            return addComputerToEmployee(employeeComputer);
        })


        const addComputerToEmployee = (employeeComputer) => {
            var assignedComputerID = employeeComputer.ComputerID
            return getComputer(assignedComputerID);
        };

        const getComputer = (employeeComputerID) => {

            $http.get(`/api/computers/${employeeComputerID}`).then((result) => {
                $scope.employee.computerID = result.data.ComputerID;
                $scope.employee.computerManufacturer = result.data.Manufacturer;
                $scope.employee.computerMake = result.data.Make;
        console.log($scope.employee);
            });
        }

    }
]);