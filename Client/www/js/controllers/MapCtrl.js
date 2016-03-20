starterControllers.controller('MapCtrl', function ($scope, EventFactory, $state, $compile) {
      function initialize() {

              
              var mapOptions = {
                        zoom: 16,
                        mapTypeId: google.maps.MapTypeId.ROADMAP
                      };
              var map = new google.maps.Map(document.getElementById("map"),
                                                       mapOptions);
              
              //Marker + infowindow + angularjs compiled ng-click
              var contentString = "<div><a ng-click='clickTest()'>Click me!</a>a></div>div>";
              var compiled = $compile(contentString)($scope);

              var infowindow = new google.maps.InfoWindow({
                content: compiled[0]
              });



              $scope.map = map;
              navigator.geolocation.getCurrentPosition(function(pos) {
                console.log(pos);
                $scope.map.setCenter(new google.maps.LatLng(pos.coords.latitude, pos.coords.longitude));
              var marker = new google.maps.Marker({
                position: new google.maps.LatLng(pos.coords.latitude, pos.coords.longitude),
                map: map,
                title: 'Uluru (Ayers Rock)'
              });
              // google.maps.event.addListener(marker, 'click', function() {
              //   infowindow.open(map,marker);
              // });
              }, function(error) {
                alert('Unable to get location: ' + error.message);
              });
      }
      google.maps.event.addDomListener(window, 'load', initialize);


      $scope.centerOnMe = function() {
        if(!$scope.map) {
          return;
        }

        $scope.loading = $ionicLoading.show({
          content: 'Getting current location...',
          showBackdrop: false
        });

      };

      $scope.clickTest = function() {
        alert('Example of infowindow with ng-click')
      };
});
