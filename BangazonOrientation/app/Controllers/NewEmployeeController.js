app.controller("NewEmployeeController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $scope.new = (Employee) => {

            $http.post("/api/employees/", Employee).then(function () {
                $location.path(`/employees`);
            }).catch((err) => {
                console.log("error posting new employee", err);
            });
        };
    }]);