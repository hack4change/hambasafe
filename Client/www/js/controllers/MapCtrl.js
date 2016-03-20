starterControllers.controller('MapCtrl', function ($scope, EventFactory, $state, $compile) {
      (function(){
        $scope.sliderDistance = 16;
     })()
        $scope.loading = $ionicLoading.show({
          content: 'Getting current location...',
          showBackdrop: false
        });

      };
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
                var gCoords = new google.maps.LatLng(pos.coords.latitude, pos.coords.longitude);
                var marker = new google.maps.Marker({
                  position: gCoords,
                  map: map,
                  title: 'Uluru (Ayers Rock)'
                });
                var locationCircle = new google.maps.Circle({
                  strokeColor: '#FF0000',
                  strokeOpacity: 0.8,
                  strokeWeight: 2,
                  fillColor: '#FF0000',
                  fillOpacity: 0.35,
                  map: map,
                  center:  gCoords,
                  radius: $scope.sliderDistance*1000
                });
                $scope.loading.hide();
              }, function(error) {
                alert('Unable to get location: ' + error.message);
              });
      }
      google.maps.event.addDomListener(window, 'load', initialize);
      $scope.$watch('sliderDistance', function (newValue, oldValue) {
        console.log('oldValue=' + oldValue);
        console.log('newValue=' + newValue);
        //do something
      });
      $scope.changeDistance(){
        console.log($scope.sliderDistance);
      }

});
