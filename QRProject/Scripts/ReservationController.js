var app = angular.module('reservationApp', []);
app.controller('reservationController', function ($scope, $http) {

    var GetAllRooms = function () {
        $http.get("/api/Rooms/")
        .then(function (response) {
            $scope.rooms = response.data;
        });
    }

    $scope.showTypeQR = function () {
        $scope.whichTypeReservation = 0;
        GetAllRooms();
    }

    $scope.showTypeManual = function () {
        $scope.whichTypeReservation = 1;
        GetAllRooms();
    }

    GetAllRooms();
});