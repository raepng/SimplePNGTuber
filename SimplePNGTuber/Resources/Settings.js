const Settings = class {
    constructor(blinkFrequency, serverPort, wsServerPort, animationHeight, animationSpeed) {
        this.blinkFrequency = blinkFrequency;
        this.serverPort = serverPort;
        this.wsServerPort = wsServerPort;
        this.animationHeight = animationHeight;
        this.animationSpeed = animationSpeed;
    }
}

var settings = new Settings(%blinkFrequency%, %serverPort%, %wsServerPort%, %animationHeight%, %animationSpeed%);