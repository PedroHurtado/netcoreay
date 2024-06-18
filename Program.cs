// See https://aka.ms/new-console-template for more information
var items = new List<int>(){
    1,2,3
};

var result = items.Filter(v=>v%2==0);
var result1 = items.Where(v=>v%2==0).Select(v=>v*v);
foreach(var item in result){
    Console.WriteLine(item);
}
/*
 Pero yo soy un amante de javascript y estoy acostumbrado a utilizar 
 filter implementa un metodo filter al sistema de link
*/

Console.WriteLine("Hello, World!");

var operations = new List<Func<int,int,int>>(){
    (a,b)=>a+b,
    (a,b)=>a-b,
    (a,b)=>a*b,
    (a,b)=>a/b,
};

foreach(var op in operations){
    op(2,2);
}

Action<Object ,Action<Object>> printer =(a,writer)=>writer(a);

var printer1 = (Object a, Action<Object> writer)=> writer(a);

printer("Hola",Console.WriteLine);
printer1("Hola",Console.WriteLine);

public static class ExtensionLinq{
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> iter, Func<T,bool> predicate){
        foreach(var item in iter){
            if(predicate(item)){
                yield return item;
            }            
        }
    }
}
