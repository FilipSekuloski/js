function insert_number(){
    document.getElementById("result1").value = '0';
    document.getElementById("result").value = '0';
};

const calculator={
    numbers:[0,1,2,3,4,5,6,7,8,9],
    symbols:["+","-","*","/"],

    memory:[],
    memory_short:"",

    digits: function(x){
        document.getElementById("result1").value+=x;
        this.memory_short+=""+x;
        console.log("previous value of short memory:",this.memory_short)
    },
    digits_symb: function(x){
        document.getElementById("result1").value+=x;
        this.memory.push(this.memory_short);
        this.memory.push(x);
        this.memory_short="";
        console.log(this.memory);
        console.log("short memory value:",this.memory_short);

    },
    result: function(){
        this.memory.push(this.memory_short);
        for(i=0;i<=this.memory.length;i++){
            if(this.memory[i]===this.symbols[0]){
                let sum=Number(this.memory[i-1]) + Number(this.memory[i+1]);
                document.getElementById("result1").value=sum;
                this.memory_short=sum;
                console.log("Result:",this.memory)
            }
            if(this.memory[i]===this.symbols[1]){
                let sum=Number(this.memory[i-1]) - Number(this.memory[i+1]);
                document.getElementById("result1").value=sum;
                this.memory_short=sum;
                console.log("Result:",this.memory)
            }
            if(this.memory[i]===this.symbols[2]){
                let sum=Number(this.memory[i-1]) * Number(this.memory[i+1]);
                document.getElementById("result1").value=sum;
                this.memory_short=sum;
                console.log("Result:",this.memory)
            }
            if(this.memory[i]===this.symbols[3]){
                let sum=Number(this.memory[i-1]) / Number(this.memory[i+1]);
                document.getElementById("result1").value=sum;
                this.memory_short=sum;
                console.log("Result:",this.memory)
            };
            
        };
    }

};