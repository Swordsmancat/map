# map
#include "stdio.h"
#include "malloc.h"
#define MAX 100
typedef char VertexType;
int visited[MAX];
typedef struct node
{
  int adjvex;
  struct node *next;
}EdgeNode;
typedef struct vexnokde
{
  VertexType data;
  EdgeNode *firstedge;
}VHeadNode;
typedef struct
{
  VHeadNode adjlist[MAX];
  int n,e;
}AdjList;
void CreateAGraph(AdjList *g,int flag)
{
  int i,j,k;
  EdgeNode *p;
  if(flag==0)
	  printf("\n将建立一个无向图。\n");
  else
	  printf("\n将建立一个有向图。\n");
  printf("请输入图的顶点数：");
  scanf("%d",&g->n );
  printf("请输入图的边数：");
  scanf("%d",&g->e );
  printf("\n请输入图的各顶点信息：\n");
  for(i=0;i<g->n;i++)
  {
    printf("第%d个顶点信息：",i+1);
	scanf("\n%c",&(g->adjlist [i].data));
	g->adjlist[i].firstedge =NULL;
  }
  printf("\n请输入边的信息，输入格式为：序号1，序号2（序号依次为0,1,2....）：\n");
  for(k=0;k<g->e;k++)
  {
    printf("请输入第%d条边：",k);
	scanf("\n%d,%d",&i,&j);
	p=(EdgeNode *)malloc(sizeof(EdgeNode));
	p->adjvex=j;
	p->next =g->adjlist [i].firstedge ;
	g->adjlist[i].firstedge =p;
	if(flag==0)
	{
	  p=(EdgeNode *)malloc(sizeof(EdgeNode));
	  p->adjvex=i;
	  p->next =g->adjlist [j].firstedge ;
	  g->adjlist [j].firstedge =p;
	}
  }
}
void DispAGraph(AdjList *g)
{
  int i;
  EdgeNode *p;
  printf("\n图的邻接表表示如下：\n");
  for(i=0;i<g->n;i++)
  {
	  printf("%2d [%c]",i,g->adjlist [i].data );
	  p=g->adjlist [i].firstedge ;
	  while(p!=NULL)
	  {
	    printf("-->[%d]",p->adjvex );
		p=p->next ;
	  }
	  printf("\n");
  }
}
void DFS(AdjList *g,int vi)
{
  EdgeNode *p;
  printf("(%d,",vi);
  printf("%c)",g->adjlist [vi].data);
  visited[vi]=1;
  p=g->adjlist [vi].firstedge ;
  while(p!=NULL)
  {
    if(visited[p->adjvex]==0)
		DFS(g,p->adjvex );
	p=p->next ;
  }
}
void BFS(AdjList *g,int vi)
{
  int i,v,visited[MAX];
  int qu[MAX],front=0,rear=0;
  EdgeNode *p;
  for(i=0;i<g->n;i++)
	  visited[i]=0;
  printf("(%d,",vi);
  printf("%c)",g->adjlist[vi].data );
  visited[vi]=1;
  rear=(rear+1)%MAX;
  qu[rear]=vi;
  while(front!=rear)
  {
    front=(front+1)%MAX;
	v=qu[front];
	p=g->adjlist[v].firstedge;
	while(p!=NULL)
	{
	  if(visited[p->adjvex]==0)
	  {
	    visited[p->adjvex]=1;
		printf("(%d,",p->adjvex);
		printf("%c)",g->adjlist[p->adjvex].data);
		rear=(rear+1)%MAX;
		qu[rear]=p->adjvex;
	  }
	  p=p->next;
	}
  }
}
void MenuGraph()
{
  printf("\n       图子系统 ");
	printf("\n================================");
	printf("\n| 1——更新邻接表              |");
	printf("\n| 2——深度优先遍历            |");
	printf("\n| 3——广度优先遍历            |");
	printf("\n| 0——返回                    |");
	printf("\n================================");
	printf("\n请输入菜单号（0-3）: ");
}

main()
{
  int i,f;
  char ch1,ch2,a;
  AdjList g;
  ch1='y';
  while(ch1=='y'||ch1=='Y')
  {
    MenuGraph();
	scanf("%c",&ch2);
	getchar();
	switch(ch2)
	{
	  case'1':
		  printf("要建立的是有向图（1）还是无向图（0），请选择（输入1或0）");
		  scanf("%d",&f);
		  CreateAGraph(&g,f);
		  DispAGraph(&g);
		  break;
	  case'2':
		  printf("请输入开始进行深度优先遍历的顶点序号（序号从0开始）：");
		  scanf("%d",&f);
		  printf("\n从顶点%d开始的广度优先遍历序列为：",f);
		  for(i=0;i<g.n ;i++)
			  visited[i]=0;
		  DFS(&g,f);
		  break;
	  case'3':
		  printf("请输入开始进行广度遍历的定点序号（序号从0开始）：");
		  scanf("%d",&i);
		  printf("\n从顶点%d开始的广度优先遍历序列为：",i);
		  BFS(&g,i);
		  break;
	  case'0':
		  ch1='n';break;
	  default:
		  printf("输入有误，请输入0-3进行选择！");
	}
	if(ch2!='0')
	{
	  printf("\n按回车键继续，按任意键返回主菜单！\n");
	  a=getchar();
	  if(a!='\xA')
	  {
	    getchar();ch1='n';
	  }
	}
  }
}
