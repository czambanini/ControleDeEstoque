# Controle de Estoque

Como entregavel do módulo de Testes Automatizados I (C#) do treinamento Diverse DEV (Mercado Eletrônico + Ada) o desafio foi criar um programa (web api ou console) para controle de estoque de produtos perecíveis, com os seguintes requisitos:
- Registrar a entrada de lotes de produtos ou itens individuais no estoque;
- Restrar a saída de quantidade solicitada de produtos
- Descartar produtos cuja data de validade tenha sido expirada
Os produtos retornados no método de registrar a saída devem ser aqueles que tem a data de validade mais próxima, caso o lote não seja informado.

## Tentativa (sincera) de usar TDD

Em uma primeira tentativa autonoma de usar Test Driven Development comecei listando todos os testes que pensei que poderiam ser feitos em cima dos requisitos. Não consegui começar a desenvolvelos antes de ter as entidades e banco de dados desenvolvidos,
e depois disso consegui desenvolver os testes mais básicos que testaria os métodos (ainda não desenvolvidos) dentro dos services.
Os testes que eu considerava menos básicos acabaram sendo desenvolvidos ao mesmo tempo junto com os métodos, os testes que deveriam testar métodos maiores (que acabaram juntando diversas validações) eu ainda não consegui desenvolver.

## Lista de testes
![#c5f015](https://via.placeholder.com/15/c5f015/000000?text=+) Produto_entrando_tem_que_estar_na_validade<br>
![#c5f015](https://via.placeholder.com/15/c5f015/000000?text=+) Produto_entrando_tem_data_de_fabricacao_valida<br>
![#c5f015](https://via.placeholder.com/15/c5f015/000000?text=+) Produto_entrando_deve_ter_quantidade_maior_que_zero<br>
![#c5f015](https://via.placeholder.com/15/c5f015/000000?text=+) Numero_de_itens_retirados_deve_ser_maior_que_zero<br>
![#c5f015](https://via.placeholder.com/15/c5f015/000000?text=+) Erro_quando_o_estoque_eh_menor_que_o_pedido<br>
![#c5f015](https://via.placeholder.com/15/c5f015/000000?text=+) Erro_quando_a_quantidade_do_lote_eh_menor_que_o_pedido<br>

Ainda não desenvolvidos:<br>
![#CCCCCC](https://via.placeholder.com/15/cccccc/000000?text=+) Incluir_novo_lote_aumenta_estoque_do_produto<br>
![#CCCCCC](https://via.placeholder.com/15/cccccc/000000?text=+) Produto_retirado_deve_estar_na_validade<br>
![#CCCCCC](https://via.placeholder.com/15/cccccc/000000?text=+) Produto_pertence_a_lote_escolhido<br>
![#CCCCCC](https://via.placeholder.com/15/cccccc/000000?text=+) Retirar_produto_diminui_quantidade_do_lote<br>
![#CCCCCC](https://via.placeholder.com/15/cccccc/000000?text=+) Retirar_produto_diminui_quantidade_do_estoque<br>
![#CCCCCC](https://via.placeholder.com/15/cccccc/000000?text=+) Lotes_vencidos_devem_ser_descartados<br>
![#CCCCCC](https://via.placeholder.com/15/cccccc/000000?text=+) Descartar_lote_diminui_quantidade_do_estoque<br>

## Descarte dos produtos vencidos

O descarte dos produtos vencidos ocorre de forma assincrona assim que o programa é executado, e em sua conclusão ele imprime no console quais foram os lotes descartados e que o descarte foi concluído:

![Alt text](/imgs/descarteconsole.png "Exibição dos lotes descartados no console")<br>
