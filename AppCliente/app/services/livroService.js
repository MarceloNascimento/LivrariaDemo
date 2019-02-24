/* Request $http RestFull GET PUT DELETE UPDATE*/
(function () {
    'use strict';

    // Request service
    app.service('LivroService', ['$http', 'messageService',
        'locationhostService',
        function ($http, messageService, locationhostService) {

            var header = {
                'contentType': false, 'async': true,
                'processData': false,
                'crossDomain': true,
                'cache-control': 'no-cache'
            };

            this.apiBase = locationhostService.apiBase + 'api/Livro';

       

            //To save or update some dto passede by front-end
            this.goSaveOrUpdate = function (dto, fn) {
                var fd = new FormData();
                var file = dto.certificadoCtGrafica;
                //fd.append('certificadoCtGrafica', dto.certificadoCtGrafica);
               
                //fd.append('codigo', dto.codigo);
                //fd.append('dataValidade', dto.data);
                //fd.append('nfeNumero', dto.nfeNumero);
                //fd.append('nome', dto.nome);
                //fd.append('po', dto.po);
                //fd.append('montadorNome', dto.montadorNome);
                //fd.append('operadorNome', dto.operadorNome);

                header = {
                    'contentType': false, 'async': true,
                    'processData': false,
                    'crossDomain': true,
                    'cache-control': 'no-cache'
                };
                //return this.save(fd, fn);
                if (dto !== null && angular.isNumber(dto.codigo) && dto.codigo > 0) {
                    return this.update(dto, fn);
                } else {
                    console.log(dto);
                    return this.save(dto, fn);
                }
            };


            //method to save access request form
            this.save = function (fd, fn) {

                $http.post(this.apiBase, fd, {
                    transformRequest: angular.identity,
                    headers: { 'Content-Type': undefined}
                }, function (success) {
                    fn();
                    console.log("salvou com sucesso!!!");
                }, function (error) {
                    console.log("erro ao salvar os dados!!!");
                });

            };

            this.update = function (fd, fn) {

                $http.put(this.apiBase, fd, {
                    transformRequest: angular.identity,
                    headers: { 'Content-Type': undefined }
                }, function (success) {
                    fn();
                    console.log("salvou com sucesso!!!");
                }, function (error) {
                    console.log("erro ao salvar os dados!!!");
                });
            };


            this.listAll = function (fn) {

                $http.get(this.apiBase, {
                    'content-type': 'application/json',
                    'crossDomain': true, 'async': true,
                    'cache-control': 'no-cache'
                }).then(fn, function (resp) {
                    return resp.data;

                }, function (error) {
                    alert(error);
                });
            };


            this.GetById = function (Id, fn) {
                $http.get(this.apiBase + '?Id=' + Id).then(fn, function (resp) {
                    fn();
                    return resp.data;
                }, function (error) {
                    messageService.danger(error);
                });
            };



            this.delete = function (codigo, fn) {
                $http.delete(this.apiBase + '?id=' + codigo, {
                    'content-type': 'application/json', 'async': true,
                    'crossDomain': true,
                    'cache-control': 'no-cache'
                }).then(fn, function (resp) {
                    console.log(resp);
                    return resp;

                }, function (error) {
                    return messageService.danger(error);
                });
            };

            this.GetAllByClient = function (codigo, fn) {
                $http.get(this.apiBaseCliente + '/GetByClient?codigo=' + codigo).then(fn, function (resp) {
                    fn(); return resp.data;
                }, function (error) {
                    messageService.danger(error);
                });
            };

        }]);

})();