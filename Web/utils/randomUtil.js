class RandomUtils {

    getRandomText() {
      let chrs = 'gre';
      let str = '';
      for (let i = 0; i < 5; i++) {
        let pos = Math.floor(Math.random() * chrs.length);
        str += chrs.substring(pos, pos + 1);
      }
      return str;
    }
    
    getRandomInterest() {
      const arr = ["Ponies", "Enveloppes", "Closets",
        "Polo", "Cables", "Tires", "Dough", "Questions",
        "Windows", "Snails", "Squares", "Select all", "Balls",
        "Purple", "Mullets", "Post-its", "Cotton", "Cinnamon",
        "Faucets", "Dry-wall", "Unselect all"];
  
      const rand = Math.floor(Math.random() * arr.length);       
      return arr[rand];  
    }    
  
  } module.exports = new RandomUtils();