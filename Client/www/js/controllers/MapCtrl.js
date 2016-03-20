starterControllers.controller('MapCtrl', function ($scope, EventFactory, $state, $compile, $ionicLoading) {
      (function(){
        $scope.sliderDistance = 10;
     })()
        $scope.loading = $ionicLoading.show({
          content: 'Getting current location...',
          showBackdrop: false
        });

      function initialize() {

              
              var mapOptions = {
                        zoom: 10,
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
                $scope.gCoords = new google.maps.LatLng(pos.coords.latitude, pos.coords.longitude);
                $scope.marker = new google.maps.Marker({
                  position: $scope.gCoords,
                  map: $scope.map,
                  title: 'Uluru (Ayers Rock)'
                });
                $scope.locationCircle = new google.maps.Circle({
                  strokeColor: '#FF0000',
                  strokeOpacity: 0.8,
                  strokeWeight: 2,
                  fillColor: '#FF0000',
                  fillOpacity: 0.35,
                  map: $scope.map,
                  center:  $scope.gCoords,
                  radius: $scope.sliderDistance*1000
                });
                $ionicLoading.hide();
              }, function(error) {
                alert('Unable to get location: ' + error.message);
              });
      }
      google.maps.event.addDomListener(window, 'load', initialize);
      $scope.$watch('sliderDistance', function (newValue, oldValue) {
        console.log($scope.map)
        $scope.locationCircle.setOptions({
          radius: $scope.sliderDistance*1000
        });
        //do something
      });
});