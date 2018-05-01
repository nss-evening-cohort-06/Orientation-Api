app.controller("NewDepartmentsController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $scope.new = (Department) => {

            $http.post("/api/departments/", Department).then(function () {
                $location.path(`/departments`);
            }).catch((err) => {
                console.log("error posting new department", err);
            });
        };
    }
])