var container;
var canvas;
var timer = 0;

//������
function init() {
canvas = document.getElementById('canvas');
container = document.createElement('div');
container.style.width = window.innerWidth + 'px';
container.style.height = window.innerHeight + 'px';
container.style.overflow = 'hidden';
container.appendChild(canvas);
document.body.appendChild(container);
document.body.style.margin = '0px'
}

//�T�C�Y�ύX����
function resize() {
container.style.width = window.innerWidth + 'px';
container.style.height = window.innerHeight + 'px';
canvas.width = window.innerWidth * window.devicePixelRatio;
canvas.height = window.innerHeight * window.devicePixelRatio;
}

window.onload = function () {
init();
resize();
};

//�u���E�U�̑傫�����ς�������ɍs������
(function () {
var timer = 0;
window.onresize = function () {
if (timer > 0) {
clearTimeout(timer);
}