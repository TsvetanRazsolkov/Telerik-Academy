'use strict'

var fs = require('fs'),
    http = require('http'),
    formidable = require('formidable'),
    uuid = require('node-uuid');

var uploadFolder = './images',
    downloadFolder = './downloads',
    port = 6969,
    imageExt = '.jpg';

function parseFormData(req, res, form) {
    var form = new formidable.IncomingForm();
    form.parse(req, function(error, fields, files) {
        var filePath = files.upload.path;
        saveFile(filePath, res);
    });
}

function saveFile(filePath, res) {
    fs.readFile(filePath, function(error, original_data) {
        var id = uuid.v1();
        var base64Image = original_data.toString('base64');
        var decodedImage = new Buffer(base64Image, 'base64');
        fs.writeFile('Images/' + id + imageExt, decodedImage, function(error) {
            if (error) {
                console.log(error);
            }
        });

        res.write('You can access image at: <a' + ' href="http://localhost:6969/images/' + id + imageExt + '" >Go to image.</a>');
        res.end();
    });
}

var server = http.createServer(function(req, res){
    if (!fs.existsSync(uploadFolder)){
        fs.mkdirSync(uploadFolder);
    }

    res.writeHead(200, {
        'content-type': 'text/html'
    });

    if (req.url === '/' && req.method.toLowerCase() === 'get') {
        fs.readFile('views/index.html', function(err, data){
            if (err) {
                console.log(err);
            }
            res.end(data);
        });
    }

    if (req.url == '/upload' && req.method.toLowerCase() == 'post') {
        parseFormData(req, res);
        return;
    }

    if (req.url.indexOf('/images') > -1) {
        var imageId = __dirname + req.url;

        res.writeHead(200, {
            'Content-Type': 'text/html'
        });

        fs.readFile(imageId, function(error, data) {
            if (error) {
                console.log(error);
                return;
            }

            res.write('<html><body><img src="data:image/jpeg;base64,')
            res.write(new Buffer(data).toString('base64'));
            res.end('"/></body></html>');
        });

        return;
    }
});

server.listen(port);
console.log('Server running on port ' + port);