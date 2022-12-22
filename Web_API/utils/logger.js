const logger = require('./loggerConfig');

class Logger {

    async info(message) {
        return logger.info(message);
    }

    async warn(warning) {
        return logger.warn(warning);
    }

    async error(error) {
        return logger.error(error);
    }

} module.exports = new Logger();