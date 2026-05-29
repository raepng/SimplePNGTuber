const Settings = class {
	constructor(blinkFrequency, serverPort, wsServerPort, animationHeight, animationSpeed, isRemote, remoteServerPort, remoteWsServerPort,) {
		this.blinkFrequency = blinkFrequency;
		this.serverPort = serverPort;
		this.wsServerPort = wsServerPort;
		this.animationHeight = animationHeight;
		this.animationSpeed = animationSpeed;
		this.isRemote = isRemote;
		this.remoteServerPort = remoteServerPort;
		this.remoteWsServerPort = remoteWsServerPort;
	}
}

var settings = new Settings(%blinkFrequency%, %serverPort%, %wsServerPort%, %animationHeight%, %animationSpeed%, %isRemote%, %remoteServerPort%, %remoteWsServerPort%);