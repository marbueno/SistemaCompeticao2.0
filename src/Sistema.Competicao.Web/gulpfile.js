var gulp        = require('gulp');
var concat      = require('gulp-concat');
var cssmin      = require('gulp-cssmin');
var uncss       = require('gulp-uncss');
var browserSync = require('browser-sync').create();

gulp.task('browserSync', function () {
    browserSync.init({
        proxy: 'localhost:5000'
    });

    gulp.watch('./Styles/**/*.css', ['css', 'cssadmin']);
    gulp.watch('./Scripts/**/*.js', ['js']);
});

gulp.task('js', function(){
    return gulp.src([
        './node_modules/bootstrap/dist/js/bootstrap.min.js',
        './node_modules/jquery/dist/jquery.min.js',
        './node_modules/jquery-ajax-unobtrusive/jquery.unobtrusive-ajax.min.js',
        './node_modules/jquery-validation/dist/jquery.validate.min.js',
        './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js',
        './node_modules/vue/dist/vue.min.js',
        './node_modules/vee-validate/dist/vee-validate.min.js',
        './node_modules/vee-validate/dist/locale/pt_BR.js',
        './Scripts/jquery-ui.js',
        './Scripts/jquery.metisMenu.js',
        './Scripts/Main.vue.js',
        './Scripts/Login.vue.js',
        './Scripts/site.js'
    ])
    .pipe(gulp.dest('wwwroot/js/'))
    .pipe(browserSync.stream());
});

gulp.task('css', function(){
    return gulp.src([
        './node_modules/bootstrap/dist/css/bootstrap.css',
        './Styles/site.css'
    ])
    .pipe(concat('site.min.css'))
    .pipe(cssmin())
    .pipe(uncss({ html: ['Views/**/*.cshtml']}))
    .pipe(gulp.dest('wwwroot/css'))
    .pipe(browserSync.stream());
});

gulp.task('cssadmin', function () {
    return gulp.src([
        './node_modules/bootstrap/dist/css/bootstrap.css',
        './Styles/jquery-ui.css',
        './Styles/admin.css'
    ])
        .pipe(concat('admin.min.css'))
        .pipe(cssmin())
        //.pipe(uncss({ html: ['Areas/Admin/Views/**/*.cshtml'] }))
        .pipe(gulp.dest('wwwroot/css'))
        .pipe(browserSync.stream());
});