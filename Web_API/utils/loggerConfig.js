const { format, createLogger, transports } = require('winston');
const { timestamp, combine, printf } = format;
const logFormat = printf(({ level, message, timestamp, stack }) => {
  return `${timestamp} ${level}: ${stack || message}`;
});

const loggerConfig = createLogger({
  format: combine(format.colorize(), timestamp({ format: 'YYYY-MM-DD HH:mm:ss' }), format.errors({ stack: true }), logFormat),
  level: "info",
  transports: [
    new transports.Console()
  ],
});

module.exports = loggerConfig;



