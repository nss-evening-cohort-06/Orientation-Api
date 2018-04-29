app.controller("EmployeeController", ["$location", "$scope", "$http",
    function ($location, $scope, $http) {

        $http.get("/api/employees/").then(function (result) {
            $scope.employees = result.data;

            getDepartments();
        });

        $scope.employeesDetail = (employeeId) => {
            $location.path(`/employees/${employeeId}`);
        };

        $scope.AddNewEmployee = () => {
            $location.path(`/employees/new`);
        };

        getDepartments = () => {

            $http.get(`/api/departments/`).then(function (result) {
                var departmentsData = result.data;
                var employees = $scope.employees;

                for (var employee in employees) {
                    for (department in departmentsData) {

                        if (employees[employee].DepartmentID === departmentsData[department].DepartmentID) {
                            $scope.employees[employee].Department = departmentsData[department].Name;
                        }
                    };
                }
            })
        }
    }
]);