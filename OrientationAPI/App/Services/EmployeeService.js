app.service("EmployeeService", function ($http, $q, $rootScope) {

    const addTEmployee = function (employee) {
        return $q((resolve, reject) => {
            $http.post(`http://localhost:50482/api/employees`, JSON.stringify(employee)).then(function (results) {
                resolve(results);
            }).catch(function (err) {
                reject("error in addEmployee in Service", err);
            });
        });
    }

    return { addEmployee }
});