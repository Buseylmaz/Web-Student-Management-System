var app = angular.module("OgretmenApp", ["ngRoute"]);
app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {

            templateUrl: "PaylasilanIcerik.html",
            controller: "PaylasilanIcerikCtrl"

        })
        
        .when("/DersiAlanOgrenciler", {
            templateUrl: "DersiAlanOgrenciler.html",
            controller: "DersiAlanOgrencilerCtrl"
        })

        .when("/OgrencilerinListesi", {
            templateUrl: "OgrencilerinListesi.html",
            controller: "OgrencilerinListesiCtrl"
        })
        .when("/Not", {
            templateUrl: "Not.html",
            controller: "NotCtrl"
        })
        
        .when("/PaylasilanIcerik", {
            templateUrl: "PaylasilanIcerik.html",
            controller: "PaylasilanIcerikCtrl"
        })
        .when("/DersListesi", {
        templateUrl: "DersListesi.html",
        controller: "DersListesiCtrl"
    });
});




//Ögrenci
app.controller("OgrencilerinListesiCtrl", function ($scope, $http) {
    $scope.disableTagButton = { 'visibility': 'hidden' };
    $scope.disableTagButton2 = { 'visibility': 'hidden' };
    $scope.disableTagButton3 = { 'visibility': 'hidden' };

    $http.get("http://localhost:53902/api/Student/TumOgrencileriGetir")
        .then(function (response) {
            $scope.ogrenciler = response.data;
        });
   

   
    
});

//Ders Listesi
app.controller("DersListesiCtrl", function ($scope, $http, $rootScope, $location) {
    $scope.disableTagButton4 = { 'visibility': 'hidden' };
    $scope.disableTagButton2 = { 'visibility': 'hidden' };
    $scope.disableTagButton = { 'visibility': 'hidden' };
    $scope.disableTagButton5 = { 'visibility': 'hidden' };
    $scope.disableTagButton6 = { 'visibility': 'hidden' };
    $scope.disableTagButton7 = { 'visibility': 'hidden' };
    $scope.disableTagButton8 = { 'visibility': 'hidden' };
    $scope.disableTagButton9 = { 'visibility': 'hidden' };
    $scope.disableTagButton10 = { 'visibility': 'hidden' };
    $scope.disableTagButton11 = { 'visibility': 'hidden' };

    $rootScope.ogrencisorgudersid = null;
    

    $http.get("http://localhost:53902/api/Course/TumDersleriGetir")
        .then(function (response) {
            $scope.dersler = response.data;
        });

   

    //Dersi Alan Ögrenciler
    $scope.DersiAlanOgrenciler = function (CID) {
        $rootScope.ogrencisorgudersid = CID;
        $location.path('/DersiAlanOgrenciler');
    }
    
});



//Dersi Alan Ögrenciler
app.controller("DersiAlanOgrencilerCtrl", function ($scope, $http, $rootScope, $location) {
    $rootScope.listelenecek = null;

    if ($rootScope.ogrencisorgudersid == undefined || $rootScope.ogrencisorgudersid == null) {
        $location.path('/DersListesi');
        Response.Write("Dersi Alan Ögrenci Bulunmamaktadır!!!Ders Listesine yönlendirileceksiniz");
    }

    $http.get("http://localhost:53902/api/StudentCourse/DersiAlanOgrencileriGetir?CID=" + $rootScope.ogrencisorgudersid)
        .then(function (response) {
            $scope.ogrenciler = response.data;
        });

});


//Not 
app.controller("NotCtrl", function ($scope, $http, $rootScope, $rootScope,$location) {
    $http.get("http://localhost:53902/api/Note/TumNotlariGetir")
        .then(function (response) {
            $scope.notlar = response.data;

        });


    //Not Sİl
    $scope.NotSil = function (NID) {
        $http.get("http://localhost:53902/api/Note/NotSil?NID=" + NID)
            .then(function (response) {
                $scope.notlar = response.data;
            });
    }


    //Not Güncelle
    $scope.NotGuncelle = function (note)
    {
        $scope.Note = note;
    }
    $scope.Guncelle = function (yeni) {
        $http.post("http://localhost:53902/api/Note/NotGuncelle", yeni).then(function (response) {
            if (response.data == true) {
                $http.get("http://localhost:53902/api/Note/TumNotlariGetir").then(function (response) {
                    $scope.notlar = response.data;
                });
            }
            else
                alert("Not Bilgisi Güncellenmedi!!!");
            $scope.Note = {};
        });
    }
   
});


//Paylaşılan İçerik
app.controller("PaylasilanIcerikCtrl", function ($scope,$http) {
    $http.get("http://localhost:53902/api/Announcement/TumIcerikleriGetir")
        .then(function (response) {
            $scope.icerikler = response.data;
             
        });


    //Duyuru Sİl
    $scope.DuyuruSil = function (ANID) {
        $http.get("http://localhost:53902/api/Announcement/DuyuruSil?ANID=" + ANID)
            .then(function (response) {
                $scope.icerikler = response.data;
            });
    }

    //Duyuru Güncelle
    $scope.DuyuruGuncelle = function (announcement) {
        $scope.Announcement = announcement;
    }
    $scope.Guncelle = function (yeni) {
        $http.post("http://localhost:53902/api/Announcement/DuyuruGuncelle", yeni).then(function (response) {
            if (response.data == true) {
                $http.get("http://localhost:53902/api/Announcement/TumIcerikleriGetir").then(function (response) {
                    $scope.icerikler = response.data;
                });
            }
            else
                alert("Duyuru Güncellenmedi!!!");
            $scope.Announcement = {};
        });
    }
});

