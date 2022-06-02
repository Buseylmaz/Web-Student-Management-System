var app = angular.module("OgrenciApp", ["ngRoute"]);
app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {

            templateUrl: "PaylasilanIcerik.html",
            controller: "PaylasilanIcerikCtrl"

        })
        .when("/DersListesi", {
            templateUrl: "DersListesi.html",
            controller: "DersListesiCtrl"
        })

        .when("/Derslerim", {
            templateUrl: "Derslerim.html",
            controller: "DerslerimCtrl"
        })
        .when("/Not", {
            templateUrl: "Not.html",
            controller: "NotCtrl"
        })
        .when("/PaylasilanIcerik", {
            templateUrl: "PaylasilanIcerik.html",
            controller: "PaylasilanIcerikCtrl"
        });
});



//Ders Listesi
app.controller("DersListesiCtrl", function ($scope, $http, $rootScope) {
    $scope.disableTagButton = { 'visibility': 'hidden' };
    $scope.disableTagButton2 = { 'visibility': 'hidden' };
    $scope.disableTagButton3 = { 'visibility': 'hidden' };
    $scope.disableTagButton5 = { 'visibility': 'hidden' };
    $scope.disableTagButton6 = { 'visibility': 'hidden' };
    $scope.disableTagButton7 = { 'visibility': 'hidden' };
    $scope.disableTagButton8 = { 'visibility': 'hidden' };
    $scope.disableTagButton9 = { 'visibility': 'hidden' };
    $scope.disableTagButton10 = { 'visibility': 'hidden' };
    $scope.disableTagButton11 = { 'visibility': 'hidden' };



    $http.get("http://localhost:53902/api/Course/TumDersleriGetir")
        .then(function (response) {
            $scope.dersler = response.data;
        });

    $scope.DersKaydet = function (CID) {
        $http.get("" + CID)
            .then(function (response) {
                $scope.icerikler = response.data;
            });
    }
    $scope.DerslerimeKaydet = function (MID) {
        $http.get("http://localhost:53902/api/MyCourses/DerslerimeKaydet" + MID)
            .then(function (response) {
                $scope.derslerim = response.data;
            });
    }
});




//Derslerim 
app.controller("DerslerimCtrl", function ($scope, $http) {
    $http.get("http://localhost:53902/api/MyCourses/TumDerslerimiGetir")
        .then(function (response) {
            $scope.derslerim = response.data;
        });

    //Derslerim Kayıt
    $scope.DerslerimeKaydet = function (MID) {
        $http.get("http://localhost:53902/api/MyCourses/DerslerimeKaydet" + MID)
            .then(function (response) {
                $scope.derslerim = response.data;
            });
    }


});


//Not 
app.controller("NotCtrl", function ($scope, $http) {
    $scope.disableTagButton6 = { 'visibility': 'hidden' };
    $scope.disableTagButton7 = { 'visibility': 'hidden' };
    $scope.disableTagButton8 = { 'visibility': 'hidden' };
    $scope.disableTagButton9 = { 'visibility': 'hidden' };
    $scope.disableTagButton11 = { 'visibility': 'hidden' };
    $scope.disableTagButton12 = { 'visibility': 'hidden' };
    $scope.disableTagButton10 = { 'visibility': 'hidden' };
    $scope.disableTagButton = { 'visibility': 'hidden' };
    $scope.disableTagButton13 = { 'visibility': 'hidden' };


    $http.get("http://localhost:53902/api/Note/OgrenciDersinNotlar%C4%B1n%C4%B1Getir?CSID=")
        .then(function (response) {
            $scope.notlar = response.data;
        });

});


//Paylaşılan İçerik
app.controller("PaylasilanIcerikCtrl", function ($scope, $http) {
    $scope.disableTagButton = { 'visibility': 'hidden' };
    $scope.disableTagButton2 = { 'visibility': 'hidden' };
    $scope.disableTagButton3 = { 'visibility': 'hidden' };
    $scope.disableTagButton9 = { 'visibility': 'hidden' };
    $scope.disableTagButton6 = { 'visibility': 'hidden' };
    $scope.disableTagButton7 = { 'visibility': 'hidden' };
    $scope.disableTagButton8 = { 'visibility': 'hidden' };
    $scope.disableTagButton11 = { 'visibility': 'hidden' };


    $http.get("http://localhost:53902/api/Announcement/TumIcerikleriGetir")
        .then(function (response) {
            $scope.icerikler = response.data;
        });

});
