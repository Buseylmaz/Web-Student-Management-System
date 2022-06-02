var app = angular.module("YoneticiApp", ["ngRoute"]);
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
        .when("/OgretmenListesi", {
        templateUrl: "OgretmenListesi.html",
        controller: "OgretmenListesiCtrl"
        })
        .when("/PaylasilanIcerik", {
        templateUrl: "PaylasilanIcerik.html",
        controller: "PaylasilanIcerikCtrl"
        });

});




//Ögtretmen
app.controller("OgretmenListesiCtrl", function ($scope, $http) {
    $http.get("http://localhost:53902/api/Teacher/TumOgretmenleriGetir")
        .then(function (response) {
        $scope.ogretmenler = response.data;
    });

    //Ögretmen Sil
    $scope.OgretmenKayitSil = function (TID) {
        $http.get("http://localhost:53902/api/Teacher/OgretmenKayitSil?TID=" + TID)
        .then(function (response) {
            $scope.ogretmenler = response.data;
        });
    };

    //Ögretmen Güncelle
    $scope.OgretmenGuncelle = function (teacher) {
        $scope.Teacher = teacher;
    }
    $scope.Guncelle = function (yeni) {
        $http.post("http://localhost:53902/api/Teacher/OgretmenGuncelle", yeni).then(function (response) {
            if (response.data == true) {
                $http.get("http://localhost:53902/api/Teacher/TumOgretmenleriGetir").then(function (response) {
                    $scope.ogretmenler = response.data;
                });
            }
            else
                alert("Ögretmen Bilgisi Güncellenmedi!!!");
            $scope.Teacher = {};
        });
    }
 
    
});


//Ögrenci
app.controller("OgrencilerinListesiCtrl", function ($scope, $http) {
    $http.get("http://localhost:53902/api/Student/TumOgrencileriGetir")
        .then(function (response) {
        $scope.ogrenciler = response.data;
        });

    //Ögrenci Sil
    $scope.OgrenciSil = function (SID) {
        $http.get("http://localhost:53902/api/Student/OgrenciSil?SID=" + SID)
            .then(function (response) {
                $scope.ogrenciler = response.data;
            });
    }

    //Ögrenci Güncelle
    $scope.OgrenciGuncelle = function (student) {
        $scope.Student = student;
    }
    $scope.Guncelle = function (yeni) {
        $http.post("http://localhost:53902/api/Student/OgrenciGuncelle", yeni).then(function (response) {
            if (response.data == true) {
                $http.get("http://localhost:53902/api/Student/TumOgrencileriGetir").then(function (response) {
                    $scope.ogrenciler = response.data;
                });
            }
            else
                alert("Ögrenci Bilgisi Güncellenmedi!!!");
        $scope.Student = {};
        });
    }
   
    
});



//Ders Listesi
app.controller("DersListesiCtrl", function ($scope, $http, $rootScope, $location) {
    $scope.disableTagButton4 = { 'visibility': 'hidden' };

    $rootScope.ogrencisorgudersid = null;
    $rootScope.ogretmensorgudersid = null;

    $http.get("http://localhost:53902/api/Course/TumDersleriGetir")
        .then(function (response) {
            $scope.dersler = response.data;
        });

    //Ders Sil
    $scope.DersSil = function (CID) {
        $http.get("http://localhost:53902/api/Course/DersSil?CID=" + CID)
        .then(function (response)
        {
            $scope.dersler = response.data;
        });
    }

    //Ders Kaydet
    $scope.DersKayitEkle = function (course) {
        $http.post("http://localhost:53902/api/Course/DersKayitEkle", course)
            .then(function (response) {
                $scope.dersler = response.data;
            });
    }

    //Ders Güncelle
    $scope.DersGuncelle = function (course)
    {
        $scope.Course = course;
    }
    $scope.Guncelle = function (yeni)
    {
        $http.post("http://localhost:53902/api/Course/DersGuncelle", yeni).then(function (response)
        {
            if (response.data == true)
            {
                    $http.get("http://localhost:53902/api/Course/TumDersleriGetir").then(function (response) {
                            $scope.dersler = response.data;
                    });
            }
            else
                alert("Ders Bilgisi Güncellenmedi!!!");
            $scope.Course = {};
        });
    }
   

    //Dersi Alan Ögrenciler
    $scope.DersiAlanOgrenciler = function (CID) {
        $rootScope.ogrencisorgudersid = CID;    
        $location.path('/DersiAlanOgrenciler');
    }


   
    
});

//Dersi Alan Ögrenciler
app.controller("DersiAlanOgrencilerCtrl", function ($scope, $http, $rootScope) {
    $rootScope.notListelenecek = null;

    $http.get("http://localhost:53902/api/StudentCourse/DersiAlanOgrencileriGetir?CID=" + $rootScope.ogrencisorgudersid )
      .then(function (response) {
      $scope.ogrenciler  = response.data;
        });


    //Not Gör
    $scope.NotGor = function (CSID) {
        $http.get("http://localhost:53902/api/Note/OgrenciDersinNotlar%C4%B1n%C4%B1Getir?CSID=" + CSID)
            .then(function (response) {
                $scope.sonuclar = response.data;

            });
    }

});



//Not 
app.controller("NotCtrl", function ($scope, $http, $rootScope, $location) {
    $scope.disableTagButton = { 'visibility': 'hidden' };
   

    $http.get("http://localhost:53902/api/Note/TumNotlariGetir")
        .then(function (response) {
            $scope.notlar = response.data;
        });


    //NotSil
    $scope.NotSil = function (CSID) {
        $http.get("http://localhost:53902/api/Note/NotSilCSIDyeGore?CSID=" + CSID)
            .then(function (response) {
                $scope.notlar = response.data;
            });
    }

    //Not Gör
    $http.get("http://localhost:53902/api/Note/OgrenciDersinNotlar%C4%B1n%C4%B1Getir?CSID=" + $rootScope.notListelenecek)
        .then(function (response) {
            $scope.notlar = response.data;
        });

    //Not Güncelle
    $scope.NotGuncelle = function (note) {
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
            $scope.Course = {};
        });
    }
   
});

//Paylaşılan İçerik
app.controller("PaylasilanIcerikCtrl", function ($scope, $http) {
    $scope.disableTagButton = { 'visibility': 'hidden' };
    $scope.disableTagButton3 = { 'visibility': 'hidden' };
    $scope.disableTagButton2 = { 'visibility': 'hidden' };
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





