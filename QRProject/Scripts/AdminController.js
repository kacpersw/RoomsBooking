var app = angular.module('adminPage', []);
app.controller('adminController', function ($scope, $http) {

    var GetAllRooms = function () {
        $http.get("/api/Rooms/")
        .then(function (response) {
            $scope.rooms = response.data;
        });
    }

    $scope.deleteRoom = function (roomId) {
        $http.delete("/api/Rooms/" + roomId)
        .then((response) => {
            GetAllRooms();
        });
    }

    $scope.addNewRoom = function (newRoom) {
        $http.post("/api/Rooms", newRoom)
        .then((response) => {
            GetAllRooms();
        });
    }

    $scope.showRooms = function () {
        $scope.showRoom = 1;
    }

    $scope.hideRooms = function () {
        $scope.showRoom = 0;
    }


    var GetAllUsers = function () {
        $http.get("/api/Users/")
        .then(function (response) {
            $scope.users = response.data;
        });
    }

    $scope.deleteUser = function (userId) {
        $http.delete("/api/Users/" + userId)
        .then((response) => {
            GetAllUsers();
        });
    }

   

    $scope.showUsers = function () {
        $scope.showUser = 1;
    }

    $scope.hideUsers = function () {
        $scope.showUser = 0;
    }


    var GetAllReservations = function () {
        $http.get("/api/Reservations/")
        .then(function (response) {
            $scope.reservations = response.data;
        });
    }

    $scope.deleteReservation = function (reservationId) {
        $http.delete("/api/Reservations/" + reservationId)
        .then((response) => {
            GetAllReservations();
        });
    }

    $scope.addNewReservation = function (newReservation) {
        $http.post("/api/Reservations", newReservation)
        .then((response) => {
            GetAllReservations();
        });
    }

    $scope.showReservations = function () {
        $scope.showReservation = 1;
    }

    $scope.hideReservations = function () {
        $scope.showReservation = 0;
    }

    var showAll = function(){
        GetAllRooms();
        GetAllUsers();
        GetAllReservations();
    }
    
    showAll();

});