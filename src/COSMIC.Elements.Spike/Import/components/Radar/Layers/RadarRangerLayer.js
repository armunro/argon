export default {
    props: {
        width: Number,
        height: Number
    },
    data() {
        return {}
    },
    methods: {
        drawRangeRing(x, y, radius, dashed) {
            if (dashed)
                this.canvas.setLineDash([10, 5]);
            this.canvas.beginPath();
            this.canvas.arc(x, y, radius, 0, 2 * Math.PI);
            this.canvas.closePath();
            this.canvas.stroke();
            this.canvas.setLineDash([]);
        },
        drawRangeCaption(text, x, y, radius, ) {
            this.canvas.fillStyle = "Cyan";
            this.canvas.font = `${16}px JetBrainsMonoRegularNerdFontComplete`;
            let coords = this.calcTextCoordinates(x, y, radius, 45);
            this.canvas.fillText(text, coords[0], coords[1]);
            coords = this.calcTextCoordinates(x, y, radius, -45);
            this.canvas.fillText(text, coords[0]-20, coords[1]);
        },
        drawRangeRings() {
            this.drawRangeRing(350, this.height, 550);
            this.drawRangeRing(350, this.height, 400, true);
            this.drawRangeRing(350, this.height, 250, true);
            this.drawRangeRing(350, this.height, 100, true);
            this.drawRangeCaption("4h", 350, this.height, 250);
            this.drawRangeCaption("6h", 350, this.height, 400);
            this.drawRangeCaption("2h", 350, this.height, 100);
        },
        calcTextCoordinates(x_center, y_center, radius, angle) {
            let angleInRadians = (angle - 90) * (Math.PI / 180);
            let new_x = x_center + radius * Math.cos(angleInRadians);
            let new_y = y_center + radius * Math.sin(angleInRadians);
            return [new_x, new_y];
        },
        init() {

            const ratio = window.devicePixelRatio;
            let canvas = document.getElementById("fp-radar-ranger-layer");
            canvas.width = this.width * ratio;
            canvas.height = this.height * ratio;
            canvas.style.width = canvas.width + "px";
            canvas.style.height = canvas.height + "px";
            this.canvasElement = canvas;
            this.canvas = canvas.getContext("2d");
            this.canvas.strokeStyle = "#a2a2a2";
            this.canvas.lineWidth = 2
            this.canvas.scale(ratio, ratio);
        }
    },
    mounted() {
        this.init();
        this.drawRangeRings();

    },
    template: `
        <canvas id="fp-radar-ranger-layer" width="{{width}}" height="{{height}}" ></canvas>
  `
}
